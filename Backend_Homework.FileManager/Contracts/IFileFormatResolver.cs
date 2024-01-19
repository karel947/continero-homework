using Backend_Homework.Convertors.Enums;

namespace Backend_Homework.FileManager.Contracts;

public interface IFileFormatResolver
{
    Format Resolve(string filePath);
}