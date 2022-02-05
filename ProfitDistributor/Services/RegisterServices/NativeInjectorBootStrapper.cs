using Microsoft.Extensions.DependencyInjection;
using ProfitDistributor.Services.Application;
using ProfitDistributor.Services.Business;
using ProfitDistributor.Services.Interfaces;
using ProfitDistributor.Services.Repositories;
using ProfitDistritor.Services.Mappers;

namespace ProfitDistributorHelper.Services.RegisterServices
{
    public static class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Alows to mapper services interfaces to services
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDatabaseWeights, DatabaseWeights>();
            services.AddSingleton<IObjectMappers, ObjectMappers>();
            services.AddScoped<IProfitService, ProfitService>();
            services.AddScoped<IProfitCalculations, ProfitCalculations>();
        }
    }
}