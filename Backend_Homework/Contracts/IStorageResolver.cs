using Backend_Homework.Enums;

namespace Backend_Homework.Contracts;

public interface IStorageResolver
{
    IStorage Resolve(StorageType storageType);
}