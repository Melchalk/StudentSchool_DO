namespace Menu.MenuActions;

public abstract class Action
{
    protected static int CommonID { get; set; } = 0;
    public string Message { get; set; } = "Действие выполняется";
    public string DoneMessage { get; set; } = "\nДействие выполнено";

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}
