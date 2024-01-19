using Backend_Homework.Convertors.Enums;
using Backend_Homework.Storages.Enums;

namespace Backend_Homework.FileManager.Implementation;

public class FileManagerOptions
{
    public string InputPath { get; set; } = null!;

    public string? OutputPath { get; set; } = null!;

    public Format? InputFormat { get; set; }

    public Format? OutputFormat { get; set; }

    public StorageType InputStorage { get; set; }

    public StorageType OutputStorage { get; set; }
}