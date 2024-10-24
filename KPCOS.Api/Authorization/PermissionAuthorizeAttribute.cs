using KPCOS.Api.Enums;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPOCOS.Domain.Errors;
using MBKC.Service.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MBKC.Service.Authorization
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public PermissionAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                SetUnauthorizedResult(context, "Bạn không được phép truy cập vào API này.");
                return;
            }

            IAccountService accountService = context.HttpContext.RequestServices.GetService<IAccountService>();
            string userName = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                SetUnauthorizedResult(context, "Không tìm thấy token");
                return;
            }

            var existedAccount = accountService.GetByUserName(userName).Result;
            if (_roles != null)
            {
                if (!_roles.Any(role => existedAccount.Role.Type.Equals(role)))
                {
                    SetForbiddenResult(context, "Bạn không được sử dụng chức năng này!");
                    return;
                }
                else
                {
                    return;
                }
            }

            if (!existedAccount.Status)
            {
                SetUnauthorizedResult(context, "You have not changed your password for the first time after registering. Please change the new password before using this function.");
                return;
            }

            bool isActiveAccount = existedAccount.Status.Equals(AccountEnum.Status.ACTIVE.ToString().ToLower());

            if (!isActiveAccount)
            {
                SetUnauthorizedResult(context, "You are not allowed to access this API.");
                return;
            }

            var expiredClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;

            if (string.IsNullOrEmpty(expiredClaim) || !long.TryParse(expiredClaim, out long expiredTimestamp))
            {
                SetUnauthorizedResult(context, "Token is expired.");
                return;
            }

            var expiredDate = DateUtil.ConvertUnixTimeToDateTime(expiredTimestamp);

            if (expiredDate <= DateTime.UtcNow)
            {
                SetUnauthorizedResult(context, "You are not allowed to access this API.");
                return;
            }

            var roleClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToLower() == "role")?.Value;

            if (string.IsNullOrEmpty(roleClaim) || !_roles.Any(role => role.Equals(roleClaim, StringComparison.OrdinalIgnoreCase)))
            {
                SetForbiddenResult(context, "You are not allowed to access this function!");
                return;
            }
        }

        private void SetUnauthorizedResult(AuthorizationFilterContext context, string message)
        {
            context.Result = new ObjectResult("Unauthorized")
            {
                StatusCode = 401,
                Value = new
                {
                    Message = JsonConvert.DeserializeObject<List<ErrorDetail>>(ErrorUtil.GetErrorString("Unauthorized", message))
                }
            };
        }

        private void SetForbiddenResult(AuthorizationFilterContext context, string message)
        {
            context.Result = new ObjectResult("Forbidden")
            {
                StatusCode = 403,
                Value = new
                {
                    Message = JsonConvert.DeserializeObject<List<ErrorDetail>>(ErrorUtil.GetErrorString("Forbidden", message))
                }
            };
        }
    }
}