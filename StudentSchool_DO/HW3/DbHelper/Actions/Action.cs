using ConsoleOptions;
using Provider.Repositories;

namespace DbHelper.Actions;

public abstract class Action
{
    protected const string NULL = "NULL";

    public string Message { get; set; }
    public string DoneMessage { get; set; }

    protected static readonly string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False;";
    protected string _request;
    protected BookRepository _bookRepository = new();

    protected int ChoiceTable()
    {
        var choice = "Выберите категорию:\n" +
            $"Читатель ({(int)Tables.Readers})\n" +
            $"Книга ({(int)Tables.Books})\n" +
            $"Номер - ";

        ConsoleHelper.Output(choice);

        var numChoice = int.Parse(ConsoleHelper.Input());

        ConsoleHelper.Output("\n");

        return numChoice;
    }

    protected Guid GetID()
    {
        ConsoleHelper.Output("Введите ID: ");

        var id = new Guid(ConsoleHelper.Input());

        ConsoleHelper.Output("\n");

        return id;
    }

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}