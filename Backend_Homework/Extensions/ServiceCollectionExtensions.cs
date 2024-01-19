using Backend_Homework.Contracts;
using Backend_Homework.FileManger;
using Backend_Homework.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Backend_Homework.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetServiceCollection(this IServiceCollection services)
    {
        return services
            .AddTransient<IFileManager, FileManager>()
            .AddSingleton<IStorageResolver, StorageResolver>()
            .AddSingleton<IConvertorResolver, ConvertorResolver>()
            .AddSingleton<IFileFormatResolver, FileFormatResolver>()
            .AddAllOfType<IStorage>(typeof(Program))
            .AddAllOfType<IConvertor>(typeof(Program));
    }

    private static IServiceCollection AddAllOfType<T>(this IServiceCollection services, Type inAssembly)
    {
        var type = typeof(T);
        var classTypes = inAssembly
            .Assembly
            .GetTypes()
            .Where(x => !x.IsAbstract && x.IsClass && x.GetInterface(type.Name) != null);

        foreach (var classType in classTypes)
        {
            services.TryAddEnumerable(new ServiceDescriptor(type, classType, ServiceLifetime.Transient));
        }

        return services;
    }
}