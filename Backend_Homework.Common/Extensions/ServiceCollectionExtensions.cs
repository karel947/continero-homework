using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Backend_Homework.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllOfType<T>(this IServiceCollection services, Type inAssembly)
    {
        var type = typeof(T);
        var classTypes = inAssembly
            .Assembly
            .GetTypes()
            .Where(x => x is { IsAbstract: false, IsClass: true } && x.GetInterface(type.Name) != null);

        foreach (var classType in classTypes)
        {
            services.TryAddEnumerable(new ServiceDescriptor(type, classType, ServiceLifetime.Transient));
        }

        return services;
    }
}