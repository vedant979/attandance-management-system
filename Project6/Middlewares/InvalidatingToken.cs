using Project6.Data.Repository.Abstraction;
using Project6.Services.Abstraction;
using System.Security.Claims;

namespace Project6.Middlewares
{
    public class InvalidatingToken : IMiddleware
    {
        private readonly IUserService userService;
       
        public InvalidatingToken(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                if(context.User?.Claims != null && context.User.Claims.Any())
                {
                    Guid id = Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                    var resp = await userService.CheckUserSessionAsync(id);
                    if (!resp)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Session expired or inactive.");
                        return;
                    }
                    await next(context);
                }
                else
                {
                    await next(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}
