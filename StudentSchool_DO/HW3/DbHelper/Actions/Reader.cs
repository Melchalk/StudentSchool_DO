namespace DbHelper.Actions;

internal class Reader : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Read;

    public Reader()
    {
        Message = "-- Выполняется чтение записи --";
        DoneMessage = "\nИскомая запись: ";
    }

    public override string PerformAction()
    {


        return DoneMessage;
    }
}
