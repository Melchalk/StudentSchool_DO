using ConsoleOptions;

namespace Menu;

public static class GeneralMenu
{
    public const string MISTAKE = "\nНекорректный ввод";
    public const string TRY_AGAIN = "Выполните попытку снова";
    public const string TRANSITION_TO_START_MENU = "Выполняется переход в главное меню";
    public const string MAIN_MENU = "Главное меню";

    public static string Start()
    =>  StartMenu.Start();

    public static bool StartCheckMistake(int numberAction)
    => StartMenu.StartCheckMistake(numberAction);

    public static void StartChoice<T>(T action) where T : MenuActions.Action
    => StartMenu.StartChoice(action);

    public static void MistakeAndTransition(string messageWarning)
    {
        ConsoleServiceColors.MistakeColor();

        ConsoleHelper.Output($"{MISTAKE}\n{messageWarning}\n");

        ConsoleServiceColors.OrdinaryColor();

        if (messageWarning == TRANSITION_TO_START_MENU)
        {
            ConsoleHelper.Input();
            throw new Exception(MAIN_MENU);
        }
    }

    internal static void PerformingAction<T>(T action) where T : MenuActions.Action
    {
        SendMessage(action.Message);

        try
        {
            ConsoleHelper.Output($"{action.PerformAction()}\n");
        }
        catch (Exception ex)
        {
            if (ex.Message == MAIN_MENU)
            {
                throw new Exception(MAIN_MENU);
            }

            MistakeAndTransition(TRY_AGAIN);
        }
    }

    internal static void SendMessage(string message)
    {
        ConsoleHelper.Clear();

        ConsoleServiceColors.HintsColor();

        ConsoleHelper.Output(message);
    }
}