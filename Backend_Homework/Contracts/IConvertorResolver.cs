using Backend_Homework.Enums;

namespace Backend_Homework.Contracts;

public interface IConvertorResolver
{
    IConvertor Resolve(Format inputFormat, Format outputFormat);
}