using Backend_Homework.Enums;

namespace Backend_Homework.Contracts;

public interface IStorage
{
    StorageType StorageType { get; }

    Task SaveFileAsync(string fileName, Stream file);

    Task<Stream> LoadFileAsync(string fileName);
}