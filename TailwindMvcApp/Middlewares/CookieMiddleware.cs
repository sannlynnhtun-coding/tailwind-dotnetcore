namespace TailwindMvcApp.Middlewares
{
    public class CookieMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_urls.Contains(context.Request.Path.ToString().ToLower()))
            {
                await next.Invoke(context);
                return;
            }

            if (context.User.Identity is { IsAuthenticated: false })
            {
                context.Response.Redirect("/");
                await next.Invoke(context);
                return;
            }

            await next.Invoke(context);
        }
        private string[] _urls = {
            "/",
            "/login",
            "/login/index"
        };
    }
}
