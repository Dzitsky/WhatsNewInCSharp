using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharp9Tests
{
    /// <summary>
    /// Атрибуты локальных функций
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/local-function-attributes"></see>
    /// </summary>
    public class AttributesOnLocalFunctions
    {
        [Test]
        public void Demo()
        {
            static bool IsValid([NotNullWhen(returnValue: true)] string? str)
            {
                return !string.IsNullOrEmpty(value: str);
            }

            string? myStr = null;
            if (IsValid(str: myStr))
            {
                int myStrLength = myStr.Length;
                Console.WriteLine(value: myStrLength);
            }

            string? myStr2 = "Hello";
            if (IsValid(str: myStr2))
            {
                int myStr2Length = myStr2.Length;
                Console.WriteLine(value: myStr2Length);
            }
        }
    }
}