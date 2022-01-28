using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharp9Tests
{
    /// <summary>
    /// ExtensionGetEnumerator (Метод GetEnumerator может быть методом расширения (например, можно перебирать в foreach кортежи))
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extension-getenumerator"></see>
    /// </summary>
    public static class MyExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this ValueTuple<T, T, T> source)
        {
            yield return source.Item1;
            yield return source.Item2;
            yield return source.Item3;
        }
    }

    public class ExtensionGetEnumerator
    {
        [Test]
        public void Demo()
        {
            
            //foreach (int value in valueTuple)
            //{
            //    Console.WriteLine(value: value);
            //}
        }
    }
}
