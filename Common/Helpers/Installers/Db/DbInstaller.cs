using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using firstDemo.Common.Abstractions;
using firstDemo.Persistence;

namespace firstDemo.Common.Helpers.Installers.Db
{
    public class DbInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );
        }
    }
}