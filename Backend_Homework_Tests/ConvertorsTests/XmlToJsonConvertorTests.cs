using System.Xml.Linq;
using Backend_Homework.Common.Extensions;
using Backend_Homework.Convertors.Enums;
using Backend_Homework.Convertors.Implementation;
using Backend_Homework_Tests.SampleData;
using Newtonsoft.Json;
using Xunit;

namespace Backend_Homework_Tests.ConvertorsTests;

public class XmlToJsonConvertorTests
{
    [Fact]
    public void ValidateConvertorConfiguration()
    {
        // Arrange
        var convertor = new XmlToJsonConvertor();

        // Assert
        Assert.Equal(Format.Xml, convertor.FromFormat);
        Assert.Equal(Format.Json, convertor.ToFormat);
    }

    [Fact]
    public async Task ValidXml_ConvertAsync_ValidJson()
    {
        // Arrange
        var input = Data.ValidXmlString;
        var convertor = new XmlToJsonConvertor();

        // Act
        var resultStream = await convertor.ConvertAsync(input.ToStream());
        var json = await resultStream!.ReadToStringAsync();

        // Assert
        var xml = XDocument.Parse(input);
        var expectedJson = JsonConvert.SerializeXNode(xml);
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public async Task InvalidJson_ConvertAsync_Exception()
    {
        // Arrange
        var input = Data.InvalidXmlString;
        var convertor = new XmlToJsonConvertor();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await convertor.ConvertAsync(input.ToStream()));
    }
}