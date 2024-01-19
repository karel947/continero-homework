using Backend_Homework.FileManger;

namespace Backend_Homework.Contracts;

public interface IFileManager
{
    Task MoveFileAsync(FileManagerOptions options);
}