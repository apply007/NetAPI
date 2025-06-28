
namespace neApi.Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("good mid1");
            await next(context);
            await context.Response.WriteAsync("good mid2");
        }
    }
}
