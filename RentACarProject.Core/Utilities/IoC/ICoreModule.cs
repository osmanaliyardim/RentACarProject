using Microsoft.Extensions.DependencyInjection;

namespace RentACarProject.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
