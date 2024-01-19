using Backend_Homework.Storages.Contracts;
using Backend_Homework.Storages.Enums;

namespace Backend_Homework.Storages.Implementation;

public class StorageResolver : IStorageResolver
{
    private readonly IEnumerable<IStorage> _storages;

    public StorageResolver(IEnumerable<IStorage> storages)
    {
        _storages = storages;
    }

    public IStorage Resolve(StorageType storageType)
    {
        var storage = _storages.FirstOrDefault(x => x.StorageType == storageType);

        if (storage is null)
        {
            throw new NotSupportedException($"Storage '{storageType}' is not supported");
        }

        return storage;
    }
}