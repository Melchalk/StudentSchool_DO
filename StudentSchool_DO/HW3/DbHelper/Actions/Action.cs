namespace DbHelper.Actions;

public abstract class Action
{
    protected const string NULL = "NULL";

    public string Message { get; set; }
    public string DoneMessage { get; set; }

    protected static readonly string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False;";

    protected string _request;

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}
