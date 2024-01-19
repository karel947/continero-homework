using Backend_Homework.Convertors.Contracts;
using Backend_Homework.Convertors.Enums;

namespace Backend_Homework.Convertors.Implementation;

public class ConvertorResolver : IConvertorResolver
{
    private readonly IEnumerable<IConvertor> _convertors;

    public ConvertorResolver(IEnumerable<IConvertor> convertors)
    {
        _convertors = convertors;
    }

    public IConvertor Resolve(Format inputFormat, Format outputFormat)
    {
        if (inputFormat == outputFormat)
        {
            return _convertors.Single(x => x is NoActionConvertor);
        }

        var convertor = _convertors.FirstOrDefault(x => x.FromFormat == inputFormat && x.ToFormat == outputFormat);

        if (convertor is null)
        {
            throw new NotSupportedException($"Conversion from '{inputFormat}' to '{outputFormat}' is not supported");
        }

        return convertor;
    }
}