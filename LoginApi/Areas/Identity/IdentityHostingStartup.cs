using System;
using LoginApi.Areas.Identity.Data;
using LoginApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LoginApi.Areas.Identity.IdentityHostingStartup))]
namespace LoginApi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginApiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginApiContextConnection")));

                services.AddDefaultIdentity<LoginApiUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LoginApiContext>();
            });
        }
    }
}