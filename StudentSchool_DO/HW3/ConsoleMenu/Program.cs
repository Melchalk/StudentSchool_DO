using ConsoleOptions;
using Menu.MenuActions;
using Menu;

while (!Exit.EndWorking)
{
    ConsoleHelper.Output(GeneralMenu.Start());
    ConsoleServiceColors.OrdinaryColor();

    int numberAction = 0;

    if (int.TryParse(ConsoleHelper.Input(), out int checkAction))
    {
        numberAction = checkAction;
    }
    else
    {
        if (GeneralMenu.StartCheckMistake(numberAction))
        {
            continue;
        }

        break;
    }

    GeneralMenu.StartChoice(ConverterNumberToAction.Convert(numberAction));
}