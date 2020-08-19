using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace firstDemo.Common.Helpers.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}