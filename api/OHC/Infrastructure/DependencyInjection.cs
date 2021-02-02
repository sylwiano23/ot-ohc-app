using Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.PdfNative;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //load external assembly to create pdf           
            var fileExtension = "dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                fileExtension = "so";
            }

            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"libwkhtmltox.{fileExtension}"));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OhcDatabase")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<IdentityRole>();

            services.AddScoped<IUserManager, UserManagerService>();
        }
    }
}
