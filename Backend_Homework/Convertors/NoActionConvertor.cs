using Backend_Homework.Contracts;
using Backend_Homework.Enums;

namespace Backend_Homework.Convertors;

public class NoActionConvertor : IConvertor
{
    public Format FromFormat => Format.NotSpecified;

    public Format ToFormat => Format.NotSpecified;

    public Task<Stream?> ConvertAsync(Stream input)
    {
        return Task.FromResult(input)!;
    }
}