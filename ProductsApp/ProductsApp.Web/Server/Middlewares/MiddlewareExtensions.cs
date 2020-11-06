using Microsoft.AspNetCore.Builder;

namespace ProductsApp.Web.Server.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void UseUniqueUsersCounter(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<UniqueUsersCounterMiddleware>();
        }
    }
}