namespace HW2;
using HW2.Actions;
using System;

static internal class Menu
{
    public const string MISTAKE = "\nНекорректный ввод";
    public const string TRY_AGAIN = "Выполните попытку снова";
    public const string TRANSITION_TO_START_MENU = "Выполняется переход в главное меню";
    public static Reader read = new();
    public static Writer write = new();
    public static Fibonacci fibonacci = new();
    public static Exit exit = new();

    public static string StartMenu()
    {
        Console.Clear();
        ConsoleServiceColors.ColorForMenu();

        string startMenuText = "---- Добро пожаловать в меню ----\n" +
            "Выберите желаемую опцию\n" +
            $"- Чтение: {read.ID}\n" +
            $"- Запись: {write.ID}\n" +
            $"- Вывод числа Фибоначчи: {fibonacci.ID}\n" +
            $"- Выход: {exit.ID}\n" +
            "Номер выбора - ";

        return startMenuText;
    }

    static string MediumMenu()
    {
        ConsoleServiceColors.ColorForMenu();

        string mediumMenuText = "\nВыберите действие:\n" +
            "Повторить операцию (1)\n" +
            "Главное меню (2)\n" +
            "Номер - ";

        return mediumMenuText;
    }

    public static void StartChoice<T>(T action) where T : Actions.Action
    {
        PerformingAction(action);

        if (action == exit)
        {
            ConsoleServiceColors.OrdinaryColor();
            return;
        }

        ConsoleHelper.Output(MediumMenu());
        ConsoleServiceColors.OrdinaryColor();

        MediumChoice(action);
    }

    public static bool StartCheckMistake(int numberAction)
    {
        bool isNotCorrectNum = !Enum.IsDefined(typeof(MenuEnum.Start), numberAction);
        if (isNotCorrectNum)
        {
            ConsoleServiceColors.MistakeColor();

            ConsoleHelper.Output("\nВнимание! Некорректный ввод\n" +
                "Повторить попытку? (y/n) - ");

            ConsoleServiceColors.OrdinaryColor();

            return ConsoleHelper.Input() == "y";
        }

        return false;
    }

    public static void MediumChoice<T>(T action) where T : Actions.Action
    {
        if (!(int.TryParse(ConsoleHelper.Input(), out int meduimAction) && Enum.IsDefined(typeof(MenuEnum.Medium), meduimAction)))
        {
            MistakeAndTransition(TRANSITION_TO_START_MENU);
        }

        if (meduimAction == 1)
        {
            StartChoice(action);
        }
    }

    public static void MistakeAndTransition(string messageWarning)
    {
        ConsoleServiceColors.MistakeColor();

        ConsoleHelper.Output($"{MISTAKE}\n{messageWarning}\n");

        ConsoleServiceColors.OrdinaryColor();

        if (messageWarning == TRANSITION_TO_START_MENU)
        {
            ConsoleHelper.Input();
        }
    }

    static void PerformingAction<T>(T action) where T : Actions.Action
    {
        SendMessage(action.Message);

        try
        {
            ConsoleHelper.Output($"{action.PerformAction()}\n");
        }
        catch
        {
            MistakeAndTransition(TRY_AGAIN);
        }
    }

    public static void SendMessage(string message)
    {
        ConsoleHelper.Clear();
        ConsoleServiceColors.HintsColor();
        ConsoleHelper.Output($"{message}\n");
    }
}