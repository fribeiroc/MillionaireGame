using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillionaireGameMvc.Services;
using MillionaireGameMvc.Data;
using MillionaireGameMvc.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace MillionaireGameMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<HttpClientService>();

            services.AddDbContext<LoginMvcContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LoginMvcContextConnection")));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<LoginMvcUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LoginMvcContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            /*The below code sets the fallback authorization policy. The fallback authorization policy
              requires all users to be authenticated, except for Razor Pages, controllers, or action methods with an authorization
              attribute. For example, Razor Pages, controllers, or action methods with [AllowAnonymous] or [Authorize(PolicyName="MyPolicy")]
              use the applied authorization attribute rather than the fallback authorization policy.*/
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
