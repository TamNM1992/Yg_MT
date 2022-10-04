//using YG.Data.Models;
//using YG.Service.UserService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Attribute = System.Attribute;

//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//public class AuthorizeAttribute : Attribute, IAuthorizationFilter
//{
//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        var user = (User)context.HttpContext.Items["User"];
//        if (user == null)
//        {
//            // not logged in
//            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
//        }
//    }
//}
//namespace YG.API.MiddleWare
//{
//    public class JwtMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly AppSettings _appSettings;

//        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
//        {
//            // lúc đăng kí
//            _next = next;
//            _appSettings = appSettings.Value;
//        }

//        public async Task Invoke(HttpContext context, IUserService userService)
//        {
//             // mỗi request sau này nhảy vào đây tiền xử lý
//            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//            if (token != null)
//                attachUserToContext(context, userService, token);

//            await _next(context);
//        }

//        private void attachUserToContext(HttpContext context, IUserService userService, string token)
//        {
//            try
//            {
//                var tokenHandler = new JwtSecurityTokenHandler();
//                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//                tokenHandler.ValidateToken(token, new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
//                    ClockSkew = TimeSpan.Zero
//                }, out SecurityToken validatedToken);

//                var jwtToken = (JwtSecurityToken)validatedToken;
//                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

//                // attach user to context on successful jwt validation
//                context.Items["User"] = userService.GetById(userId);
//            }
//            catch
//            {
//                // do nothing if jwt validation fails
//                // user is not attached to context so request won't have access to secure routes
//            }
//        }
//    }
//}