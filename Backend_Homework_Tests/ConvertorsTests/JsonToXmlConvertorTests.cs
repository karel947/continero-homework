using System.Xml.Linq;
using Backend_Homework.Convertors;
using Backend_Homework.Enums;
using Backend_Homework.Extensions;
using Backend_Homework_Tests.SampleData;
using Newtonsoft.Json;
using Xunit;

namespace Backend_Homework_Tests.ConvertorsTests;

public class JsonToXmlConvertorTests
{
    [Fact]
    public void ValidateConvertorConfiguration()
    {
        // Arrange
        var convertor = new JsonToXmlConvertor();

        // Assert
        Assert.Equal(Format.Json, convertor.FromFormat);
        Assert.Equal(Format.Xml, convertor.ToFormat);
    }

    [Fact]
    public async Task ValidJson_ConvertAsync_ValidXml()
    {
        // Arrange
        var input = Data.ValidJsonString;
        var convertor = new JsonToXmlConvertor();

        // Act
        var resultStream = await convertor.ConvertAsync(input.ToStream());
        var xml = await resultStream!.ReadToStringAsync();

        // Assert
        Assert.Equal(JsonConvert.DeserializeXNode(input)!.ToString(SaveOptions.DisableFormatting), xml);
    }

    [Fact]
    public async Task InvalidJson_ConvertAsync_Exception()
    {
        // Arrange
        var input = Data.InvalidJsonString;
        var convertor = new JsonToXmlConvertor();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await convertor.ConvertAsync(input.ToStream()));
    }
}