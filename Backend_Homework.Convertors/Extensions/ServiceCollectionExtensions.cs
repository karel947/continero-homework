using Backend_Homework.Common.Extensions;
using Backend_Homework.Convertors.Contracts;
using Backend_Homework.Convertors.Enums;
using Backend_Homework.Convertors.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework.Convertors.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConvertors(this IServiceCollection services)
    {
        return services
            .AddSingleton<IConvertorResolver, ConvertorResolver>()
            .AddAllOfType<IConvertor>(typeof(Format));
    }
}