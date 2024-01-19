using Backend_Homework.Contracts;
using Backend_Homework.Convertors;
using Backend_Homework.Enums;

namespace Backend_Homework.Resolvers;

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