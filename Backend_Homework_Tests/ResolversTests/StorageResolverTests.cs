using Backend_Homework.Storages.Contracts;
using Backend_Homework.Storages.Enums;
using Backend_Homework.Storages.Implementation;
using Backend_Homework_Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Backend_Homework_Tests.ResolversTests;

public class StorageResolverTests : TestBase
{
    private readonly IStorageResolver _storageResolver = ServiceProvider.GetRequiredService<IStorageResolver>();

    [Fact]
    public void FileWithNoExtension_Resolve_FileSystemStorage()
    {
        // Arrange
        var storageType = StorageType.FileSystem;

        // Act
        var storage = _storageResolver.Resolve(storageType);

        // Assert
        Assert.IsType<FileSystemStorage>(storage);
    }
}