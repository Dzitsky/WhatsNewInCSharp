using NUnit.Framework;
using System;

namespace CSharp9Tests
{
    /// <summary>
    /// ExtendingPartialMethods (Расширение частичных методов)
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extending-partial-methods"></see>
    /// </summary>
    public class ExtendingPartialMethods
    {
        private partial class MyClass
        {
            public partial string GetMessage(int param);
        }

        private partial class MyClass
        {
            public partial string GetMessage(int param)
            {
                return $"Message: {param}.";
            }
        }

        [Test]
        public void Demo()
        {
            MyClass myClass = new MyClass();
            Console.WriteLine(value: myClass.GetMessage(param: 1));
        }
    }
}
