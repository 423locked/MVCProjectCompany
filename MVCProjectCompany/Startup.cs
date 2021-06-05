using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCProjectCompany.Domain;
using MVCProjectCompany.Domain.Repositories.Abstract;
using MVCProjectCompany.Domain.Repositories.EntityFramework;
using MVCProjectCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;



        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            //connecting services (Repos and a repo data manager)
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<DataManager>();

            //connecting database context
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //setting up the identity server
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //setting up authentication cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "companyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddControllersWithViews()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Order of the middleware is really important!

            if (env.IsDevelopment())  
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

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
