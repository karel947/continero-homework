using Backend_Homework.Convertors.Extensions;
using Backend_Homework.FileManager.Contracts;
using Backend_Homework.FileManager.Implementation;
using Backend_Homework.Storages.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework.FileManager.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFileManager(this IServiceCollection services)
    {
        return services
            .AddConvertors()
            .AddStorages()
            .AddTransient<IFileManager, Implementation.FileManager>()
            .AddSingleton<IFileFormatResolver, FileFormatResolver>();
    }
}