using Microsoft.Extensions.DependencyInjection;
using System;

namespace RentACarProject.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider serviceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            serviceProvider = services.BuildServiceProvider();

            return services;
        }
    }
}
