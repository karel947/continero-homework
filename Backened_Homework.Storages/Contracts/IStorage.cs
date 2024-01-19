using Backend_Homework.Storages.Enums;

namespace Backend_Homework.Storages.Contracts;

public interface IStorage
{
    StorageType StorageType { get; }

    Task SaveFileAsync(string fileName, Stream file);

    Task<Stream> LoadFileAsync(string fileName);
}