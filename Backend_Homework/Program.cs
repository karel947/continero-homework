using Backend_Homework.Contracts;
using Backend_Homework.Extensions;
using Backend_Homework.FileManger;
using Backend_Homework.Resolvers;
using Backend_Homework.UI;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // Service provider
        var serviceProvider = new ServiceCollection()
            .SetServiceCollection()
            .BuildServiceProvider();

        // Options parser
        await Parser
            .Default
            .ParseArguments<CommandLineOptions>(args)
            .WithParsedAsync(async options =>
            {
                var fileManager = serviceProvider.GetRequiredService<IFileManager>();
               
                var fileManagerOptions = new FileManagerOptions
                {
                    InputPath = options.SourceLocation,
                    OutputPath = options.DestinationLocation,
                    InputFormat = options.FromFormat,
                    OutputFormat = options.ToFormat,
                    InputStorage = options.InputStorageType,
                    OutputStorage = options.OutputStorageType
                };

                await fileManager.MoveFileAsync(fileManagerOptions);
            });
    }
}