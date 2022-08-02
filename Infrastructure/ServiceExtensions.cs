using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Interface.Interface;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddDbContext<DDDContext>();
            return services;
        }
    }
}
