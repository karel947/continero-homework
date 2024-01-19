using System.Xml;
using System.Xml.Linq;
using Backend_Homework.Contracts;
using Backend_Homework.Enums;
using Backend_Homework.Extensions;
using Newtonsoft.Json;

namespace Backend_Homework.Convertors;

public class XmlToJsonConvertor: IConvertor
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