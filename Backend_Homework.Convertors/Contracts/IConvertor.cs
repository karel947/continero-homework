using Backend_Homework.Convertors.Enums;

namespace Backend_Homework.Convertors.Contracts;

public interface IConvertor
{
    Format FromFormat { get; }

    Format ToFormat { get; }

    Task<Stream?> ConvertAsync(Stream input);
}