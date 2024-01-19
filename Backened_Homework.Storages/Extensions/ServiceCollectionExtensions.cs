using Backend_Homework.Common.Extensions;
using Backend_Homework.Storages.Contracts;
using Backend_Homework.Storages.Enums;
using Backend_Homework.Storages.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework.Storages.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorages(this IServiceCollection services)
    {
        return services
            .AddSingleton<IStorageResolver, StorageResolver>()
            .AddAllOfType<IStorage>(typeof(StorageType));
    }
}