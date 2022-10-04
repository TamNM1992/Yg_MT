//using YG.API.Providers;
//using YG.Common.Enums;
//using YG.Service.AuthorityServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;

//namespace YG.API.Attributes
//{
//    public class RoleAttribute : Attribute, IActionFilter
//    {
//        public Role[] Roles { get; set; }
//        public RoleAttribute(params Role[] roles)
//        {
//            Roles = roles;
//        }

//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            // không thể khởi tạo service thông qua contructor như bình thường 
//            // phải tạo ra 1 cái là provider, đây là 1 cách để lấy service đã được khởi tạo ra dùng

//            var httpContext = (IHttpContextAccessor)StaticServiceProvider.Provider.GetService(typeof(IHttpContextAccessor));
//            var authorityService = (IRoleService)httpContext.HttpContext.RequestServices.GetService(typeof(IRoleService));

//            // lấy token
//            Microsoft.Extensions.Primitives.StringValues authTokens;
//            context.HttpContext.Request.Headers.TryGetValue("Authorization", out authTokens);
//            var _token = authTokens.FirstOrDefault().Replace("Bearer ", "");
//            var handler = new JwtSecurityTokenHandler();
//            var jwtSecurityToken = handler.ReadJwtToken(_token);
//            Guid userId = Guid.Empty;
//            Guid.TryParse(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "id").Value, out userId);

//            var isCheked = authorityService.CheckUserRole(Roles, userId);

//            if (!isCheked)
//            {
//                context.Result = new JsonResult("NoPermission")
//                {
//                    StatusCode = 405,
//                    Value = new
//                    {
//                        Status = "Error",
//                        Message = "Sorry, You don't have permission for the acction."
//                    },
//                };
//            }
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            Console.WriteLine("OnActionExecuted");
//        }
//    }
//}
