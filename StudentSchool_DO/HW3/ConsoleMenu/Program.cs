using ConsoleOptions;
using Menu.MenuActions;
using Menu;

while (!Exit.EndWorking)
{
    ConsoleHelper.Output(GeneralMenu.Start());
    ConsoleServiceColors.OrdinaryColor();

    int numberAction;
    if (int.TryParse(ConsoleHelper.Input(), out int checkAction) && checkAction > 0 && checkAction <= (int)MenuEnum.Start.Exit)
    {
        numberAction = checkAction;
    }
    else
    {
        if (GeneralMenu.StartCheckMistake())
        {
            continue;
        }

        break;
    }

    try
    {
        GeneralMenu.StartChoice(ConverterNumberToAction.Convert(numberAction));
    }
    catch
    {
        continue;
    }
}