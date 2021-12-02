using System;
using ASPBoysGirlsIdentity.Areas.Identity.Data;
using ASPBoysGirlsIdentity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPBoysGirlsIdentity.Areas.Identity.IdentityHostingStartup))]
namespace ASPBoysGirlsIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginRegisterDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginRegisterDBContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<LoginRegisterDBContext>();
            });
        }
    }
}