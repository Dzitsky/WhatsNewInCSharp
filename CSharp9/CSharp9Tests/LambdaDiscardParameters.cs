using NUnit.Framework;
using System;

namespace CSharp9Tests
{
    /// <summary>
    /// Lambda discard parameters (Если в лямбда-выражениях или анонимных функциях не нужны параметры, то можно их проигнорировать заменив на знак "_")
    /// <see href="https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/proposals/csharp-9.0/lambda-discard-parameters"></see>
    /// </summary>
    public class LambdaDiscardParameters
    {
        private static void ShowMessage(Func<int, string, string> convert)
        {
            string result = convert(arg1: 100, arg2: "Hello world!");
            Console.WriteLine(value: result);
        }

        [Test]
        public void Demo()
        {
            ShowMessage(convert: (_, _) => "New message");
        }
    }
}
