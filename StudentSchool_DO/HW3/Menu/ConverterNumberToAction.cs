using Menu.MenuActions;
namespace Menu;

public class ConverterNumberToAction
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
        else if (numberOfID == DbActions.ID)
        {
            return new DbActions();
        }
        else //if (numberOfID == Exit.ID)
        {
            return new Exit();
        }
    }
}
