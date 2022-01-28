using System;

namespace CSharp9Tests
{
    /// <summary>
    /// CovariantReturnTypes (Переопределение возвращаемого типа у метода)
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/covariant-returns"></see>
    /// </summary>
    public class CovariantReturnTypes
    {
        private abstract class BaseClass
        {
            public abstract Shape GetShape();
        }

        private class ChildClass : BaseClass
        {
            // класс Square должен быть наследником Shape
            public override Square GetShape()
            {
                throw new NotImplementedException();
            }
        }

        private abstract class Shape
        {

        }

        private class Square : Shape
        {

        }
    }
}
