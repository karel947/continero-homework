using Backend_Homework.Enums;

namespace Backend_Homework.Contracts;

public interface IFileFormatResolver
{
    Format Resolve(string filePath);
}