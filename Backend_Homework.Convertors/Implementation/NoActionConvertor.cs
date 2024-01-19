using Backend_Homework.Convertors.Contracts;
using Backend_Homework.Convertors.Enums;

namespace Backend_Homework.Convertors.Implementation;

public class NoActionConvertor : IConvertor
{
    public Format FromFormat => Format.NotSpecified;

    public Format ToFormat => Format.NotSpecified;

    public Task<Stream?> ConvertAsync(Stream input)
    {
        return Task.FromResult(input)!;
    }
}