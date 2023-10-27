namespace HW2;

internal static class ConsoleHelper
{
    public static void Output(string outMessage)
    {
        Console.Write(outMessage);
    }

    public static string Input()
    {
        return Console.ReadLine();
    }

    public static void Clear()
    {
        Console.Clear();
    }
}
