using API.Data;
using API.Interfaces;
using API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AppServiceExtensions
{


    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
             options.UseSqlite(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<ILibraryRepository, LibraryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var autoMapperLicenseKey = config["AutoMapper:LicenseKey"];
        if (!string.IsNullOrEmpty(autoMapperLicenseKey))
        {
            services.AddAutoMapper(cfg => cfg.LicenseKey = autoMapperLicenseKey, typeof(Program));
        }
        
        return services;
    }
}
