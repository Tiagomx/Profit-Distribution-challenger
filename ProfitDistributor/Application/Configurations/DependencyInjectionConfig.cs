using System;
using Microsoft.Extensions.DependencyInjection;
using ProfitDistributorHelper.Services.RegisterServices;

namespace ProfitDistributor.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}