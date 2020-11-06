using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductsApp.Core.Entities;
using ProductsApp.Core.Services;
using Reinforced.Tecture;

namespace ProductsApp.Web.Server.Middlewares
{
    public class UniqueUsersCounterMiddleware
    {
        private RequestDelegate RequestDelegate { get; }

        private string CookieKey { get; } = "UniqueUserId";

        public UniqueUsersCounterMiddleware(RequestDelegate requestDelegate)
        {
            RequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context, ITecture tecture)
        {
            var uniqueUserId = context.Request.Cookies[CookieKey];
            if (uniqueUserId == null)
            {
                uniqueUserId = Guid.NewGuid().ToString();
                context.Response.Cookies.Append(CookieKey, uniqueUserId);
            }
            
            tecture.Do<Statistic>().Add(new UserSession(Guid.Parse(uniqueUserId), DateTime.Now));
            await tecture.SaveAsync();
            
            await RequestDelegate(context);
        }
    }
}