using Backend_Homework.FileManager.Implementation;

namespace Backend_Homework.FileManager.Contracts;

public interface IFileManager
{
    Task MoveFileAsync(FileManagerOptions options);
}