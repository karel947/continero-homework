using System.Xml.Linq;
using Backend_Homework.Convertors.Enums;
using Backend_Homework.FileManager.Contracts;
using Backend_Homework.FileManager.Implementation;
using Backend_Homework.Storages.Enums;
using Backend_Homework_Tests.Helpers;
using Backend_Homework_Tests.SampleData;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Backend_Homework_Tests.FileManagerTests;

public class FileManagerTests : TestBase
{
    [Fact]
    public async Task ValidXmlAndOutputFormatJson_MoveFileAsync_ValidJson()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.ValidXmlFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.json"),
            InputFormat = Format.Xml,
            OutputFormat = Format.Json,
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act
        await fileManager.MoveFileAsync(fileMangerOptions);

        // Assert
        Assert.True(File.Exists(fileMangerOptions.OutputPath));
        Assert.Null(Record.Exception(() => JsonConvert.DeserializeObject(File.ReadAllText(fileMangerOptions.OutputPath))));
    }

    [Fact]
    public async Task SameInputAndOutputFormat_MoveFileAsync_OnlyMovedFile()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.ValidJsonFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.json"),
            InputFormat = Format.Xml,
            OutputFormat = Format.Xml,
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act
        await fileManager.MoveFileAsync(fileMangerOptions);

        // Assert
        Assert.True(File.Exists(fileMangerOptions.OutputPath));
        Assert.Null(Record.Exception(() => JsonConvert.DeserializeObject(File.ReadAllText(fileMangerOptions.OutputPath))));
    }

    [Fact]
    public async Task FileWithoutExtensionAndNotFormatProvided_MoveFileAsync_OnlyMovedFile()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.WithoutExtensionFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output"),
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act
        await fileManager.MoveFileAsync(fileMangerOptions);

        // Assert
        Assert.True(File.Exists(fileMangerOptions.OutputPath));
        Assert.Equal(await File.ReadAllTextAsync(fileMangerOptions.InputPath), await File.ReadAllTextAsync(fileMangerOptions.OutputPath));
    }


    [Fact]
    public async Task ValidJsonAndOutputFormatXml_MoveFileAsync_ValidXml()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.ValidJsonFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.xml"),
            InputFormat = Format.Json,
            OutputFormat = Format.Xml,
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act
        await fileManager.MoveFileAsync(fileMangerOptions);

        // Assert
        Assert.True(File.Exists(fileMangerOptions.OutputPath));
        Assert.Null(Record.Exception(() => XDocument.Parse(File.ReadAllText(fileMangerOptions.OutputPath))));
    }

    [Fact]
    public async Task InvalidXml_MoveFileAsync_Exception()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.InvalidXmlFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.json"),
            InputFormat = Format.Xml,
            OutputFormat = Format.Json,
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await fileManager.MoveFileAsync(fileMangerOptions));
        Assert.Empty(Directory.GetFiles(tempDirectory.TempDirectoryPath));
    }

    [Fact]
    public async Task InvalidJson_MoveFileAsync_Exception()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.InvalidJsonFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.xml"),
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await fileManager.MoveFileAsync(fileMangerOptions));
        Assert.Empty(Directory.GetFiles(tempDirectory.TempDirectoryPath));
    }

    [Fact]
    public async Task NotSupportedFileType_MoveFileAsync_NotSupportedException()
    {
        // Arrange
        var fileManager = ServiceProvider.GetRequiredService<IFileManager>();
        using var tempDirectory = new TempDirectory();
        var fileMangerOptions = new FileManagerOptions
        {
            InputPath = PathProvider.GetSampleFilePath(Files.SampleCsvFile),
            OutputPath = Path.Combine(tempDirectory.TempDirectoryPath, "output.xml"),
            InputStorage = StorageType.FileSystem,
            OutputStorage = StorageType.FileSystem
        };

        // Act & Assert
        await Assert.ThrowsAsync<NotSupportedException>(async () => await fileManager.MoveFileAsync(fileMangerOptions));
        Assert.Empty(Directory.GetFiles(tempDirectory.TempDirectoryPath));
    }
}