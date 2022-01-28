using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Text;

namespace SourceGenerator
{
    //https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
    [Generator]
    public class MySourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            StringBuilder stringBuilder = new StringBuilder(value: @"
			using System;
			namespace HelloWorldGenerated
			{
			    public static class HelloWorld
			    {
			        public static void SayHello() 
			        {
			            Console.WriteLine(""Hello from generated code!"");
			            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
			");

            IEnumerable<SyntaxTree> syntaxTrees = context.Compilation.SyntaxTrees;
            foreach (SyntaxTree tree in syntaxTrees)
            {
                stringBuilder.AppendLine(value: $@"Console.WriteLine(@"" - {tree.FilePath}"");");
            }

            stringBuilder.Append(value: @"
			        }
			    }
			}");

            string text = stringBuilder.ToString();
            SourceText sourceText = SourceText.From(text: text, encoding: Encoding.UTF8);
            context.AddSource(hintName: "helloWorldGenerator", sourceText: sourceText);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            
        }
    }
}
