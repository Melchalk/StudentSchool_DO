﻿using ConsoleOptions;

namespace Menu;

internal class RepeatMenu
{
    internal static string MediumMenu()
    {
        ConsoleServiceColors.ColorForMenu();

        string mediumMenuText = "\nВыберите действие:\n" +
            $"Повторить операцию ({MenuEnum.Medium.Repeat})\n" +
            $"Главное меню ({MenuEnum.Medium.StartMenu})\n" +
            "Номер - ";

        return mediumMenuText;
    }

    internal static void MediumChoice<T>(T action) where T : MenuActions.Action
    {
        if (!(int.TryParse(ConsoleHelper.Input(), out int meduimAction) && Enum.IsDefined(typeof(MenuEnum.Medium), meduimAction)))
        {
            GeneralMenu.MistakeAndTransition(GeneralMenu.TRANSITION_TO_START_MENU);
        }

        if (meduimAction == 1)
        {
            StartMenu.StartChoice(action);
        }
    }
}