using Backend_Homework.Contracts;
using Backend_Homework.Enums;

namespace Backend_Homework.Resolvers;

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