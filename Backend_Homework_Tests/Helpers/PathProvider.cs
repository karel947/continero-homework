namespace Backend_Homework_Tests.Helpers;

public static class PathProvider
{
    private static readonly string SampleDataPath = Path.Combine(Directory.GetCurrentDirectory(), "SampleData");

    public static string GetSampleFilePath(string fileName)
    {
        var filePath = Path.Combine(SampleDataPath, fileName);

        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"Cannot run test. File '{filePath}' not found");
        }

        return Path.Combine(SampleDataPath, fileName);
    }
}