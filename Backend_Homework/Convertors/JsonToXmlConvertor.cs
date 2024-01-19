using System.Xml.Linq;
using Backend_Homework.Contracts;
using Backend_Homework.Enums;
using Backend_Homework.Extensions;
using Newtonsoft.Json;

namespace Backend_Homework.Convertors;

public class JsonToXmlConvertor : IConvertor
{
    public Format FromFormat => Format.Json;

    public Format ToFormat => Format.Xml;

    public async Task<Stream?> ConvertAsync(Stream input)
    {
        var text = await input.ReadToStringAsync();

        try
        {
            var xml = JsonConvert.DeserializeXNode(text)!.ToString(SaveOptions.DisableFormatting);
            return xml.ToStream();
        }
        catch (Exception ex) when (ex is NullReferenceException or JsonReaderException)
        {
            throw new ArgumentException($"Provided file is not valid {FromFormat}", ex);
        }
    }
}