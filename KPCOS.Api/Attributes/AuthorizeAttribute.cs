using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using KPCOS.Api.Constants;

namespace KPCOS.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var username = context.HttpContext.Items["Username"] as string;
            var userRole = context.HttpContext.Items["UserRole"] as string;

            if (username == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if (_roles.Any() && !_roles.Contains(userRole))
            {
                context.Result = new JsonResult(new { message = "Forbidden" })
                { StatusCode = StatusCodes.Status403Forbidden };
            }
        }

        // Thêm các phương thức static để dễ dàng sử dụng
        public static AuthorizeAttribute Manager() => new AuthorizeAttribute(PermissionAuthorizeConstant.Manager);
        public static AuthorizeAttribute Customer() => new AuthorizeAttribute(PermissionAuthorizeConstant.Customer);
        public static AuthorizeAttribute ConsultingStaff() => new AuthorizeAttribute(PermissionAuthorizeConstant.ConsultingStaff);
        public static AuthorizeAttribute DesignStaff() => new AuthorizeAttribute(PermissionAuthorizeConstant.DesignStaff);
        public static AuthorizeAttribute ConstructionStaff() => new AuthorizeAttribute(PermissionAuthorizeConstant.ConstructionStaff);
    }
}