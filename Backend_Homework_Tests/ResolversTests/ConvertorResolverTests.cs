using Backend_Homework.Convertors.Contracts;
using Backend_Homework.Convertors.Enums;
using Backend_Homework.Convertors.Implementation;
using Backend_Homework_Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Backend_Homework_Tests.ResolversTests;

public class ConvertorResolverTests : TestBase
{
    private readonly IConvertorResolver _convertorResolver = ServiceProvider.GetRequiredService<IConvertorResolver>();

    [Fact]
    public void XmlToJson_Resolve_JsonToXmlConvertor()
    {
        // Arrange
        var inputFormat = Format.Json;
        var outputFormat = Format.Xml;

        // Act
        var convertor = _convertorResolver.Resolve(inputFormat, outputFormat);

        // Assert
        Assert.IsType<JsonToXmlConvertor>(convertor);
    }

    [Fact]
    public void JsonToXml_Resolve_XmlToJsonConvertor()
    {
        // Arrange
        var inputFormat = Format.Xml;
        var outputFormat = Format.Json;

        // Act
        var convertor = _convertorResolver.Resolve(inputFormat, outputFormat);

        // Assert
        Assert.IsType<XmlToJsonConvertor>(convertor);
    }

    [Fact]
    public void XmlToXml_Resolve_XmlToJsonConvertor()
    {
        // Arrange
        var inputFormat = Format.Xml;
        var outputFormat = Format.Xml;

        // Act
        var convertor = _convertorResolver.Resolve(inputFormat, outputFormat);

        // Assert
        Assert.IsType<NoActionConvertor>(convertor);
    }
}