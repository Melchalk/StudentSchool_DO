namespace ConsoleOptions;

public static class ConsoleServiceColors
{
    static public void ColorForMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    public static void OrdinaryColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void MistakeColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public static void HintsColor()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
}
