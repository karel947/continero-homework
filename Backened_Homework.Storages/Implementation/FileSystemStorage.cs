using Backend_Homework.Storages.Contracts;
using Backend_Homework.Storages.Enums;

namespace Backend_Homework.Storages.Implementation;

public class FileSystemStorage : IStorage
{
    public StorageType StorageType => StorageType.FileSystem;

    public async Task SaveFileAsync(string fileName, Stream file)
    {
        await using var fileStream = File.Create(fileName);
        file.Seek(0, SeekOrigin.Begin);
        await file.CopyToAsync(fileStream);
    }

    public Task<Stream> LoadFileAsync(string fileName)
    {
        return Task.FromResult(File.OpenRead(fileName) as Stream);
    }
}