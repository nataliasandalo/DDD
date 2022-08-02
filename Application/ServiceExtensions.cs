using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services.AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
