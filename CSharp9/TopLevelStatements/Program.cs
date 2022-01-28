using System;

Console.WriteLine("ada");

Console.WriteLine(value: args.Length);
ShowMessage(message: "Some method!");
Show.Message(message: "Some method from class!");
Console.ReadLine();

static void ShowMessage(string message)
{
    Console.WriteLine(value: message);
}

internal class Show
{
    internal static void Message(string message)
    {
        Console.WriteLine(value: message);
    }
}