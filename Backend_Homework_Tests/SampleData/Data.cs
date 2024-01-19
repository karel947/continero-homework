namespace Backend_Homework_Tests.SampleData;

public static class Data
{
    public const string ValidJsonString = @"{ ""key"": 4 }";
    public const string InvalidJsonString = @"{ ""key"" ""5"" }";

    public const string ValidXmlString = @"<note>\r\n  <to>Tove</to>\r\n</note>";
    public const string InvalidXmlString = @"<note <<<< note/>";
}