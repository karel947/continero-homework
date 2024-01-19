using Backend_Homework.Common.Extensions;
using Backend_Homework.Storages.Implementation;
using Backend_Homework_Tests.Helpers;
using Backend_Homework_Tests.SampleData;
using Xunit;

namespace Backend_Homework_Tests.StoragesTests;

public class FileSystemStorageTests
{
    private static readonly FileSystemStorage FileSystemStorage = new();

    [Fact]
    public async Task ValidFile_SaveFileAsync_FileSaved()
    {
        // Arrange
        const string sampleText = "sample text";
        using var tempDirectory = new TempDirectory();
        var outputFilePath = Path.Combine(tempDirectory.TempDirectoryPath, "output.txt");

        // Act
        await FileSystemStorage.SaveFileAsync(outputFilePath, sampleText.ToStream());

        // Assert
        Assert.Equal(sampleText, await File.ReadAllTextAsync(outputFilePath));
    }

    [Fact]
    public async Task ValidFile_LoadFileAsync_FileLoaded()
    {
        // Arrange
        using var tempDirectory = new TempDirectory();
        var inputFilePath = PathProvider.GetSampleFilePath(Files.SampleTextFile);

        // Act
        var loadedFile = await FileSystemStorage.LoadFileAsync(inputFilePath);

        // Assert
        Assert.Equal(await File.ReadAllTextAsync(inputFilePath), await loadedFile.ReadToStringAsync());
    }
}