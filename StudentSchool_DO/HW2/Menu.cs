namespace HW2;

static internal class Menu
{
    static public Read read = new();
    static public Write write = new();
    static public Fibonacci fibonacci = new();
    static public Exit exit = new();
    static public List<Action> actions = new() { read, write, fibonacci, exit };
    public const string mistake = "\nНекорректный ввод";
    public const string tryAgain = "Выполните попытку снова";
    public const string transitionToStartMenu = "Выполняется переход в главное меню";

    public static int? StartMenu()
    {
        Console.Clear();
        ConsoleServiceColors.ColorForMenu();
        Console.WriteLine("---- Добро пожаловать в меню ----");
        Console.WriteLine("Выберите желаемую опцию");
        Console.WriteLine($"- Чтение: {actions.IndexOf(read)}\n- Запись: {actions.IndexOf(write)}" +
            $"\n- Вывод числа Фибоначчи: {actions.IndexOf(fibonacci)}\n- Выход: {actions.IndexOf(exit)}");
        Console.Write("\nНомер выбора - ");
        ConsoleServiceColors.OrdinaryColor();

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
            ConsoleServiceColors.OrdinaryColor();
            return;
        }

        MediumMenu(numOfAction);
    }

    static void MediumMenu(int numOfAction)
    {
        ConsoleServiceColors.ColorForMenu();
        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("Повторить операцию (1)");
        Console.WriteLine("Главное меню (2)");
        Console.Write("\nНомер - ");
        ConsoleServiceColors.OrdinaryColor();

        if (!(int.TryParse(Console.ReadLine(), out int meduimAction) && (meduimAction == 1 || meduimAction == 2)))
            MistakeAndTransition(transitionToStartMenu);

        if (meduimAction == 1)
            Choice(numOfAction);
    }

    public static void MistakeAndTransition(string messageWarning)
    {
        ConsoleServiceColors.MistakeColor();
        Console.WriteLine(mistake);
        Console.Write(messageWarning);
        ConsoleServiceColors.OrdinaryColor();

        if (messageWarning == transitionToStartMenu)
            Console.ReadLine();
    }

    static void PerformingAction<T>(T action) where T : Action
    {
        SendMessage(action.Message);
        Console.WriteLine(action.PerformAction());
    }

    public static void SendMessage(string message)
    {
        Console.Clear();
        ConsoleServiceColors.HintsColor();
        Console.WriteLine(message);
    }
}
