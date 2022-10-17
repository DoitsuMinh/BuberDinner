using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, 
                ValidationRegisterCommandBehavior>();
            services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
