using Backend_Homework.Contracts;
using Backend_Homework.Extensions;
using Backend_Homework.FileManger;
using Backend_Homework.UI.Options;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Homework.UI;

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
                try
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
              
            });
    }
}