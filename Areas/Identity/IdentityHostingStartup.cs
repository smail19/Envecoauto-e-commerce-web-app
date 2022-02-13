using System;
using Envecoauto.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: HostingStartup(typeof(Envecoauto.Areas.Identity.IdentityHostingStartup))]
namespace Envecoauto.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options =>
            { options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;


                })
             
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}