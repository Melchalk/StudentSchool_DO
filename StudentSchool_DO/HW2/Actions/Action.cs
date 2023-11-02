namespace HW2.Actions;

internal class Action
{
    protected static int CommonID { get; set; } = 0;
    public int ID { get; set; } = CommonID;
    public string Message { get; set; } = "Действие выполняется";
    public string DoneMessage { get; set; } = "\nДействие выполнено";

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}