using NUnit.Framework;

namespace CSharp9Tests
{
    /// <summary>
    /// Target-Typed Conditional Expression
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-conditional-expression"></see>
    /// </summary>
    public class TargetTypedConditionalExpressions
    {
        [Test]
        public void Demo1()
        {
            // Явного приведение к int? не требуется
            int? number = false ? 1 : null;
        }
    }
}
