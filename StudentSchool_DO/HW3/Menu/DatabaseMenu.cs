using ConsoleOptions;
using DbHelper.Actions;
using DbHelper;
using Menu.MenuActions;

namespace Menu;

public class DatabaseMenu
{
    const string TRANSITION_TO_DB_MENU = "Выполняется переход в меню БД";
    const string DB_MENU = "Меню работы с БД";

    public static string DbMenu()
    {
        ConsoleServiceColors.ColorForMenu();

        string DbMenuText = "---- Выполняется работа с БД ----\n" +
            "Выберите действие:\n" +
            $"Создать ({(int)DbEnum.Create})\n" +
            $"Прочитать ({(int)DbEnum.Read})\n" +
            $"Обновить ({(int)DbEnum.Update})\n" +
            $"Удалить ({(int)DbEnum.Delete})\n" +
            "Номер - ";

        return DbMenuText;
    }


    public static void StartChoice<T>(T action) where T : DbHelper.Actions.Action
    {
        PerformingAction(action);

        ConsoleHelper.Output(RepeatMenu.MediumMenu(DB_MENU));
        ConsoleServiceColors.OrdinaryColor();

        MediumChoice(action);
    }

    internal static void MediumChoice<T>(T action) where T : DbHelper.Actions.Action
    {
        if (!(int.TryParse(ConsoleHelper.Input(), out int meduimAction) &&
            meduimAction > 0 && meduimAction <= (int)DbEnum.Delete))
        {
            ConsoleHelper.Output($"{GeneralMenu.MISTAKE}\n{TRANSITION_TO_DB_MENU}\n");

            ConsoleHelper.Input();
        }

        if (meduimAction == (int)MenuEnum.Medium.Repeat)
        {
            StartChoice(action);
        }
        else if (meduimAction == (int)MenuEnum.Medium.StartMenu) { }
        {
            StartMenu.StartChoice(new DbActions());
        }
    }

    internal static void PerformingAction<T>(T action) where T : DbHelper.Actions.Action
    {
        GeneralMenu.SendMessage(action.Message);

        try
        {
            ConsoleHelper.Output($"{action.PerformAction()}\n");
        }
        catch
        {
            GeneralMenu.MistakeAndTransition(GeneralMenu.TRY_AGAIN);
        }
    }
}