using ConsoleOptions;
using DbHelper;

namespace Menu;

internal class RepeatMenu
{
    internal static string MediumMenu(string menu)
    {
        ConsoleServiceColors.ColorForMenu();

        string mediumMenuText = "\nВыберите действие:\n" +
            $"Повторить операцию ({(int)MenuEnum.Medium.Repeat})\n" +
            $"{menu} ({(int)MenuEnum.Medium.StartMenu})\n" +
            "Номер - ";

        return mediumMenuText;
    }

    internal static void MediumChoice<T>(T action) where T : MenuActions.Action
    {
        if (!(int.TryParse(ConsoleHelper.Input(), out int meduimAction) &&
            meduimAction > 0 && meduimAction <= (int)MenuEnum.Medium.StartMenu))
        {
            GeneralMenu.MistakeAndTransition(GeneralMenu.TRANSITION_TO_START_MENU);
        }

        if (meduimAction == (int)MenuEnum.Medium.Repeat)
        {
            StartMenu.StartChoice(action);
        }
    }
}