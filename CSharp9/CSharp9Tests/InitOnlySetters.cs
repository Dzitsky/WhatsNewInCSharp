using NUnit.Framework;

namespace CSharp9Tests
{
    /// <summary>
    /// Init Only Setters
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init"></see>
    /// </summary>
    public class InitOnlySetters
    {
        [Test]
        public void Demo()
        {
            MyClass myClass = new MyClass()
            {
                Id = 1,
                Name = "initial name"
            };

            //myClass.Id = 2;
            //myClass.Name = "modified name";
        }

        private class MyClass
        {
            private readonly string _name;

            public int Id { get; init; }

            public string Name
            {
                get => _name;
                init => _name = value;
            }
        }
    }
}
