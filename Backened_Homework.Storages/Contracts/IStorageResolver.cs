using Backend_Homework.Storages.Enums;

namespace Backend_Homework.Storages.Contracts;

public interface IStorageResolver
{
    IStorage Resolve(StorageType storageType);
}