using Backend_Homework.Convertors.Contracts;
using Backend_Homework.FileManager.Contracts;
using Backend_Homework.Storages.Contracts;

namespace Backend_Homework.FileManager.Implementation;

public class FileManager : IFileManager
{
    private readonly IStorageResolver _storageResolver;
    private readonly IConvertorResolver _convertorResolver;
    private readonly IFileFormatResolver _fileFormatResolver;

    public FileManager(
        IStorageResolver storageResolver, 
        IConvertorResolver convertorResolver,
        IFileFormatResolver fileFormatResolver)
    {
        _storageResolver = storageResolver;
        _convertorResolver = convertorResolver;
        _fileFormatResolver = fileFormatResolver;
    }

    public async Task MoveFileAsync(FileManagerOptions options)
    {
        var inputStorage = _storageResolver.Resolve(options.InputStorage);
        var outputStorage = _storageResolver.Resolve(options.OutputStorage);
        var inputFormat = options.InputFormat?? _fileFormatResolver.Resolve(options.InputPath);
        var outputFormat = options.OutputFormat ?? _fileFormatResolver.Resolve(options.OutputPath!);
        var convertor = _convertorResolver.Resolve(inputFormat, outputFormat);

        await using var fileContent = await inputStorage.LoadFileAsync(options.InputPath);
        await using var convertedContent = await convertor.ConvertAsync(fileContent);
        await outputStorage.SaveFileAsync(options.OutputPath!, convertedContent!);
    }
}