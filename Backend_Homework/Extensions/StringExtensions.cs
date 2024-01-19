using System.Text;

namespace Backend_Homework.Extensions;

public static class StringExtensions
{

    public static Stream ToStream(this string s)
    {
        return s.ToStream(Encoding.UTF8);
    }

    public static Stream ToStream(this string s, Encoding encoding)
    {
        return new MemoryStream(encoding.GetBytes(s));
    }
}