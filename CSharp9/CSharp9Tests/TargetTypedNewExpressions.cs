using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharp9Tests
{
    /// <summary>
    /// Target-typed 'new' expressions (Определение типа из контекста)
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new"></see>
    /// </summary>
    public class TargetTypedNewExpressions
    {
        /// <summary>
        /// Инициализация переменных
        /// </summary>
        [Test]
        public void Demo1()
        {
            // Полная запись
            MyClass myClass1 = new MyClass();

            // Благодаря var более компактно
            var myClass2 = new MyClass();

            // Теперь доступен обратный синтаксис
            MyClass myClass3 = new();
        }

        /// <summary>
        /// Применение в методах
        /// </summary>
        [Test]
        public void Demo2()
        {
            static MyClass LocalMethod(DateTime dt)
            {
                return new();
            }

            MyClass myClass = LocalMethod(dt: new(year: 2021, month: 2, day: 10));
        }

        /// <summary>
        /// Применение в определении коллекций
        /// </summary>
        [Test]
        public void Demo3()
        {
            List<MyClass> list = new()
            {
                new() { SomeProperty = 1 },
                new() { SomeProperty = 2 },
                new() { SomeProperty = 3 }
            };
        }

        #region Types

        private class MyClass
        {
            public int SomeProperty { get; set; }
        }

        #endregion
    }
}
