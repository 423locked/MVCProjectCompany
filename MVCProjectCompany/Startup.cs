using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // adding MVC
            services.AddControllersWithViews()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Order of the middleware is really important!

            // While developing, it's necessary to see exceptions and errors.
            if (env.IsDevelopment())  app.UseDeveloperExceptionPage();

            // Connecting the routing
            app.UseRouting();

            // Connecting static files (html, css, js)
            app.UseStaticFiles();

            // Register mapping (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
