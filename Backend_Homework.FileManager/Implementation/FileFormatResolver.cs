using Backend_Homework.Convertors.Enums;
using Backend_Homework.FileManager.Contracts;

namespace Backend_Homework.FileManager.Implementation;

public class FileFormatResolver : IFileFormatResolver
{
    public Format Resolve(string filePath)
    {
        var extension = Path.GetExtension(filePath).Replace(".", string.Empty);

        if (extension.Length == 0)
        {
            return Format.NotSpecified;
        }

        if (!Enum.TryParse<Format>(extension, true, out var format))
        {
            throw new NotSupportedException($"Files with extension '{filePath}' are not supported");
        }

        return format;
    }
}