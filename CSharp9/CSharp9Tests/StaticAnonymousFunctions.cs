using NUnit.Framework;
using System;

namespace CSharp9Tests
{
    /// <summary>
    /// Static anonymous functions (Статические лямбда-выражения (анонимные функции))
    /// Для предотвращения непреднамеренного сохранения локальных переменных или состояния экземпляров лямбда-выражением.
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/static-anonymous-functions"></see>
    /// </summary>
    public class StaticAnonymousFunctions
    {
        public static void ShowMessage(Func<string, string> convert)
        {
            Console.WriteLine(value: convert(arg: "Hello World!"));
        }

        [Test]
        public void Demo()
        {
            string underline = "_";
            ShowMessage(convert: myStr => myStr.Replace(oldValue: " ", newValue: underline));

            //ShowMessage(convert: static myStr => myStr.Replace(oldValue: " ", newValue: underline)); // A static anonymous function cannot contain a reference to 'underline'

            const string dash = "-";
            ShowMessage(convert: static myStr => myStr.Replace(oldValue: " ", newValue: dash));
        }
    }
}