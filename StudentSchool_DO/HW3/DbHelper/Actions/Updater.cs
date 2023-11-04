namespace DbHelper.Actions;

internal class Updater : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Update;

    public Updater()
    {
        Message = "-- Выполняется обновление записи --";
        DoneMessage = "\nОбновление записи выполнено";
    }

    public override string PerformAction()
    {


        return DoneMessage;
    }
}
