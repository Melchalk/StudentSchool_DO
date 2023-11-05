using DbHelper.Actions;

namespace DbHelper;

public class ConverterNumberToDbAction
{
    public static Actions.Action Convert(int numberOfID)
    {
        if (numberOfID == Creater.ID)
        {
            return new Creater();
        }
        else if (numberOfID == Reader.ID)
        {
            return new Reader();
        }
        else if (numberOfID == Remover.ID)
        {
            return new Remover();
        }
        else if (numberOfID == Updater.ID)
        {
            return new Updater();
        }

        throw new Exception();
    }
}
