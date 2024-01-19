using Backend_Homework.Convertors.Enums;

namespace Backend_Homework.Convertors.Contracts;

public interface IConvertorResolver
{
    IConvertor Resolve(Format inputFormat, Format outputFormat);
}