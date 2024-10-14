using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["AccessToken"];

            Console.WriteLine($"AccessToken from cookie: {token ?? "null"}");

            if (token != null)
                AttachUserToContext(context, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "sub").Value;
                var userRole = jwtToken.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

                Console.WriteLine($"JWT Validation Successful");
                Console.WriteLine($"Username: {username}");
                Console.WriteLine($"UserRole: {userRole ?? "null"}");

                context.Items["Username"] = username;
                context.Items["UserRole"] = userRole;

                Console.WriteLine("User information attached to context");
                Console.WriteLine($"Context Username: {context.Items["Username"]}");
                Console.WriteLine($"Context UserRole: {context.Items["UserRole"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JWT Validation failed: {ex.Message}");
            }
        }
    }
}