namespace Backend_Homework_Tests.Helpers;

public class TempDirectory : IDisposable
{
    public string TempDirectoryPath { get; }

    public TempDirectory()
    {
        var randomFolderName = Path.GetRandomFileName(); // Random name
        TempDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), randomFolderName);

        Directory.CreateDirectory(TempDirectoryPath);
    }

    public void Dispose()
    {
        Directory.Delete(TempDirectoryPath, true);
    }
}