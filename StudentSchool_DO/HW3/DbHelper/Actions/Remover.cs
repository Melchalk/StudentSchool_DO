namespace DbHelper.Actions;

internal class Remover : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Delete;

    public Remover()
    {
        Message = "-- Выполняется удаление записи --";
        DoneMessage = "\nУдаление записи выполнено";
    }

    public override string PerformAction()
    {


        return DoneMessage;
    }
}
