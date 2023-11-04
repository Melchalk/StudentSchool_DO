namespace DbHelper.Actions;

public abstract class Action
{
    public string Message { get; set; }
    public string DoneMessage { get; set; }

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}
