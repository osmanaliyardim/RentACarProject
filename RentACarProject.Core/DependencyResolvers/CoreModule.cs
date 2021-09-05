﻿using System.Diagnostics;
using RentACarProject.Core.CrossCuttingConcerns.Caching;
using RentACarProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using RentACarProject.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RentACarProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
