using Backend_Homework.Contracts;
using Backend_Homework.Enums;
using Backend_Homework_Tests.Helpers;
using Backend_Homework_Tests.SampleData;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Backend_Homework_Tests.ResolversTests;

public class FileFormatResolverTests : TestBase
{
    private readonly IFileFormatResolver _fileFormatResolver = ServiceProvider.GetRequiredService<IFileFormatResolver>();

    [Fact]
    public void FileWithJsonExtension_Resolve_JsonFormat()
    {
        // Arrange
        var inputPath = Files.ValidJsonFile;

        // Act
        var format = _fileFormatResolver.Resolve(inputPath);

        // Assert
        Assert.Equal(Format.Json, format);
    }

    [Fact]
    public void FileWithXmlExtension_Resolve_XmlFormat()
    {
        // Arrange
        var inputPath = Files.ValidXmlFile;

        // Act
        var format = _fileFormatResolver.Resolve(inputPath);

        // Assert
        Assert.Equal(Format.Xml, format);
    }

    [Fact]
    public void FileWithCsvExtension_Resolve_Exception()
    {
        // Arrange
        var inputPath = Files.SampleCsvFile;

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => _fileFormatResolver.Resolve(inputPath));
    }

    [Fact]
    public void FileWithNoExtension_Resolve_Exception()
    {
        // Arrange
        var inputPath = Files.WithoutExtensionFile;

        // Act
        var format = _fileFormatResolver.Resolve(inputPath);

        // Assert
        Assert.Equal(Format.NotSpecified, format);
    }
}