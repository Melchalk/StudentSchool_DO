using Menu.MenuActions;
namespace Menu;

public static class ConverterNumberToAction
{
    public static MenuActions.Action Convert(int numberOfID)
    {
        if (numberOfID == Reader.ID)
        {
            return GeneralMenu.read;
        }
        else if (numberOfID == Writer.ID)
        {
            return GeneralMenu.write;
        }
        else if (numberOfID == Fibonacci.ID)
        {
            return GeneralMenu.fibonacci;
        }
        else //(numberOfID == Menu.exit.ID)
        {
            return GeneralMenu.exit;
        }
    }
}
