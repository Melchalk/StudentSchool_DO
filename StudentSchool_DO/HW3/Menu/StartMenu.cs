using ConsoleOptions;
using Menu.MenuActions;
using System;

namespace Menu;

internal class StartMenu
{
    public static string Start()
    {
        ConsoleHelper.Clear();
        ConsoleServiceColors.ColorForMenu();

        string startMenuText = "---- Добро пожаловать в меню ----\n" +
            "Выберите желаемую опцию\n" +
            $"- Чтение: {Reader.ID}\n" +
            $"- Запись: {Writer.ID}\n" +
            $"- Вывод числа Фибоначчи: {Fibonacci.ID}\n" +
            $"- Выход: {Exit.ID}\n" +
            "Номер выбора - ";

        return startMenuText;
    }

    public static void StartChoice<T>(T action) where T : MenuActions.Action
    {
        GeneralMenu.PerformingAction(action);

        if (action is Exit)
        {
            ConsoleServiceColors.OrdinaryColor();
            return;
        }

        ConsoleHelper.Output(RepeatMenu.MediumMenu());
        ConsoleServiceColors.OrdinaryColor();

        RepeatMenu.MediumChoice(action);
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
}