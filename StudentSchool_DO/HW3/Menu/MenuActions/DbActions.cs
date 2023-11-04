using ConsoleOptions;
using DbHelper;

namespace Menu.MenuActions;

internal class DbActions : Action
{
    public static int ID { get; private set; } = (int)MenuEnum.Start.DbActions;

    public DbActions()
    {
        DoneMessage = "\n";
    }

    public override string PerformAction()
    {
        Console.Write(DatabaseMenu.DbMenu());

        int numberAction;
        if (int.TryParse(ConsoleHelper.Input(), out int checkAction))
        {
            numberAction = checkAction;
        }
        else
        {
            throw new Exception();
        }

        DatabaseMenu.StartChoice(ConverterNumberToDbAction.Convert(numberAction));

        ConsoleServiceColors.OrdinaryColor();

        return DoneMessage;
    }
}
