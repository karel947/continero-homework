namespace Backend_Homework.Extensions;

public static class StreamExtensions
{
    public static async Task<string> ReadToStringAsync(this Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        var streamReader = new StreamReader(stream);
        return await streamReader.ReadToEndAsync();
    }
}