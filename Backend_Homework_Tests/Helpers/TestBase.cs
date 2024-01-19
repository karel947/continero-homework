using Backend_Homework.FileManager.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework_Tests.Helpers;

public class TestBase
{
    public static IServiceProvider ServiceProvider { get; } = new ServiceCollection()
        .AddFileManager()
        .BuildServiceProvider();
}