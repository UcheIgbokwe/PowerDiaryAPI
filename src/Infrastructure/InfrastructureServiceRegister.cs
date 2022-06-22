using Application.Contracts.Infrastructure.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //Register Logger used within the UoW for each Repo.
            // var serviceProvider = services.BuildServiceProvider();
            // var logger = serviceProvider.GetService<ILogger<LogisticsRepository>>();
            // services.AddSingleton(typeof(ILogger), logger);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}