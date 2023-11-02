using ConsoleOptions;
using Menu.MenuActions;
using System;

namespace Menu;

internal static class StartMenu
{
    public static string Start()
    {
        ConsoleHelper.Clear();
        ConsoleServiceColors.ColorForMenu();

        string startMenuText = "---- Добро пожаловать в меню ----\n" +
            "Выберите желаемую опцию\n" +
            $"- Чтение: {GeneralMenu.read.ID}\n" +
            $"- Запись: {GeneralMenu.write.ID}\n" +
            $"- Вывод числа Фибоначчи: {GeneralMenu.fibonacci.ID}\n" +
            $"- Выход: {GeneralMenu.exit.ID}\n" +
            "Номер выбора - ";

        return startMenuText;
    }

    public static void StartChoice<T>(T action) where T : MenuActions.Action
    {
        GeneralMenu.PerformingAction(action);

        if (action == GeneralMenu.exit)
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