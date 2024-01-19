using System.Xml;
using System.Xml.Linq;
using Backend_Homework.Common.Extensions;
using Backend_Homework.Convertors.Contracts;
using Backend_Homework.Convertors.Enums;
using Newtonsoft.Json;

namespace Backend_Homework.Convertors.Implementation;

public class XmlToJsonConvertor : IConvertor
{
    public Format FromFormat => Format.Xml;

    public Format ToFormat => Format.Json;

    public async Task<Stream?> ConvertAsync(Stream input)
    {
        var text = await input.ReadToStringAsync();

        try
        {
            var xml = XDocument.Parse(text);
            var json = JsonConvert.SerializeXNode(xml);

            return json.ToStream();
        }
        catch (XmlException e)
        {
            throw new ArgumentException($"Provided file is not valid {FromFormat}", e);
        }
    }
}