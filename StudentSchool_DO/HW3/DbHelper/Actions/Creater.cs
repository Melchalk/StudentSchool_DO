namespace DbHelper.Actions;

internal class Creater : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Create;

    public Creater()
    {
        Message = "-- Выполняется создание записи --";
        DoneMessage = "\nСоздание записи выполнено";
    }

    public override string PerformAction()
    {
        

        return DoneMessage;
    }
}
