using Menu.MenuActions;
namespace Menu;

public static class ConverterNumberToAction
{
    public static MenuActions.Action Convert(int numberOfID)
    {
        if (numberOfID == Reader.ID)
        {
            return new Reader();
        }
        else if (numberOfID == Writer.ID)
        {
            return new Writer();
        }
        else if (numberOfID == Fibonacci.ID)
        {
            return new Fibonacci();
        }
        else //if (numberOfID == Exit.ID)
        {
            return new Exit();
        }
    }
}
