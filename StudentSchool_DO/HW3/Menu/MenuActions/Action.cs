namespace Menu.MenuActions;

public abstract class Action
{
    public string Message { get; set; }
    public string DoneMessage { get; set; } = "Действие выполняется";

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}
