using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsApp.Core.Channels;
using ProductsApp.Data;
using ProductsApp.Web.Server.Middlewares;
using Reinforced.Tecture;
using Reinforced.Tecture.Entry;
using Reinforced.Tecture.Runtimes.EFCore.Aspects.Orm;

namespace ProductsApp.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            var connectionString = Configuration.GetConnectionString("ProductsDb");
            services.AddDbContext<ProductsDbContext>( options => options.UseSqlServer(connectionString));
            
            services.AddScoped(GetTectureInstance);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseUniqueUsersCounter();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
        
        private static ITecture GetTectureInstance(IServiceProvider serviceProvider)
        {
            var context = new LazyDisposable<ProductsDbContext>(serviceProvider.GetService<ProductsDbContext>);
            
            var builder = new TectureBuilder();

            builder.WithChannel<Db>(v => v.UseEfCoreOrm(context));

            return builder.Build();
        }
    }
    
}
