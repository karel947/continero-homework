using Backend_Homework.Enums;

namespace Backend_Homework.Contracts;

public interface IConvertor
{
    Format FromFormat { get; }

    Format ToFormat { get; }

    Task<Stream?> ConvertAsync(Stream input);
}