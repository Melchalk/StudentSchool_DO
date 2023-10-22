namespace HW2;

static internal class Menu
{
    static public Read read = new();
    static public Write write = new();
    static public Fibonacci fibonacci = new();
    static public Exit exit = new();
    static public List<Action> actions = new() { read, write, fibonacci, exit };
    const string mistake = "\nНекорректный ввод";
    const string tryAgain = "Выполните попытку снова";

    public static int? StartMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("---- Добро пожаловать в меню ----");
        Console.WriteLine("Выберите желаемую опцию");
        Console.WriteLine($"- Чтение: {actions.IndexOf(read)}\n- Запись: {actions.IndexOf(write)}" +
            $"\n- Вывод числа Фибоначчи: {actions.IndexOf(fibonacci)}\n- Выход: {actions.IndexOf(exit)}");
        Console.Write("\nНомер выбора - ");
        Console.ForegroundColor = ConsoleColor.White;

        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            return null;
        }
    }

    public static void Choice(int numOfAction)
    {
        PerformingAction(actions[numOfAction]);

        if (actions[numOfAction] == exit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        MediumMenu(numOfAction);
    }

    static void MediumMenu(int numOfAction)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("Повторить операцию (1)");
        Console.WriteLine("Главное меню (2)");
        Console.Write("\nНомер - ");
        Console.ForegroundColor = ConsoleColor.White;

        if (!(int.TryParse(Console.ReadLine(), out int meduimAction) && (meduimAction == 1 || meduimAction == 2)))
            MistakeAndTransition();

        if (meduimAction == 1)
            Choice(numOfAction);
    }

    public static void MistakeAndTransition()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mistake);
        Console.WriteLine(tryAgain);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void PerformingAction<T>(T action) where T : Action
    {
        SendMessage(action.Message);
        Console.WriteLine(action.PerformAction());
    }

    public static void SendMessage(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
    }
}
