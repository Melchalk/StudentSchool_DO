namespace Menu;

public static class ConverterNumberToAction
{
    public static MenuActions.Action Convert(int numberOfID)
    {
        if (numberOfID == GeneralMenu.read.ID)
        {
            return GeneralMenu.read;
        }
        else if (numberOfID == GeneralMenu.write.ID)
        {
            return GeneralMenu.write;
        }
        else if (numberOfID == GeneralMenu.fibonacci.ID)
        {
            return GeneralMenu.fibonacci;
        }
        else //(numberOfID == Menu.exit.ID)
        {
            return GeneralMenu.exit;
        }
    }
}
