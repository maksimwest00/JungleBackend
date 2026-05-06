using System.Reflection;
using FluentValidation;
using JungleBackend.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace JungleBackend.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = typeof(DepedencyInjection).Assembly;

        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        services.AddValidatorsFromAssembly(typeof(DepedencyInjection).Assembly);

        return services;
    }
}