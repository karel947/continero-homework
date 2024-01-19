using System.Xml.Linq;
using Backend_Homework.Common.Extensions;
using Backend_Homework.Convertors.Implementation;
using Backend_Homework_Tests.SampleData;
using Xunit;

namespace Backend_Homework_Tests.ConvertorsTests;

public class NoActionConvertorTests
{
    [Fact]
    public async Task ValidXml_NoActionConvertor_ValidXml()
    {
        // Arrange
        var input = Data.ValidXmlString;
        var convertor = new NoActionConvertor();

        // Act
        var resultStream = await convertor.ConvertAsync(input.ToStream());
        var actualXml = await resultStream!.ReadToStringAsync();

        // Assert
        var expectedXml = XDocument.Parse(input).ToString(SaveOptions.DisableFormatting);
        Assert.Equal(expectedXml, actualXml);
    }

    [Fact]
    public async Task ValidJson_NoActionConvertor_ValidJson()
    {
        // Arrange
        var input = Data.ValidJsonString;
        var convertor = new NoActionConvertor();

        // Act
        var resultStream = await convertor.ConvertAsync(input.ToStream());
        var actualJson = await resultStream!.ReadToStringAsync();

        // Assert
        Assert.Equal(input, actualJson);
    }
}