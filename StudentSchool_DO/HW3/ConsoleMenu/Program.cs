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

    try
    {
        GeneralMenu.StartChoice(ConverterNumberToAction.Convert(numberAction)); //не уччитываются огр на цифры сверху
    }
    catch
    {
        continue;
    }
}