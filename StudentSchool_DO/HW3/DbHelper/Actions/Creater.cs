using ConsoleOptions;
using DbModels;
using Microsoft.Data.SqlClient;

namespace DbHelper.Actions;

internal class Creater : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Create;

    public Creater()
    {
        Message = "-- Выполняется создание записи --\n";
        DoneMessage = "\nСоздание записи выполнено";
        _request = "INSERT INTO Readers (Id, Fullname, Telephone, RegistrationAddress, Age) " +
            "VALUES ({0})";
    }

    public override string PerformAction()
    {
        if (ChoiceTable()== (int)Tables.Readers)
        {
            CreateReader();
        }
        else
        {
            CreateBook();
        }

        return DoneMessage;
    }

    private void CreateReader()
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(_request, ReaderData());
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        int sqlDataReader = sqlCommand.ExecuteNonQuery();
    }

    private void CreateBook()
    {
        DbBook book = new()
        {
            Id = Guid.NewGuid()
        };

        ConsoleHelper.Output("Введите название: ");
        book.Title = ConsoleHelper.Input().Trim();

        ConsoleHelper.Output("Введите автора: ");
        var author = ConsoleHelper.Input().Trim();
        if (author.Length > 0)
        {
            book.Author = author;
        }
        else
        {
            book.Author = null;
        }

        ConsoleHelper.Output("Введите количество стр: ");
        book.NumberPages = int.Parse(ConsoleHelper.Input());

        ConsoleHelper.Output("Введите дату публикации: ");
        var date = ConsoleHelper.Input();
        book.YearPublishing = int.Parse(date);

        ConsoleHelper.Output("Введите город: ");
        var city = ConsoleHelper.Input().Trim();
        if (city.Length > 0)
        {
            book.CityPublishing = city;
        }
        else
        {
            book.CityPublishing = null;
        }

        ConsoleHelper.Output("Введите номер холла: ");
        var hall = ConsoleHelper.Input().Trim();
        if (hall.Length > 0)
        {
            book.HallNo = int.Parse(hall);
        }
        else
        {
            book.HallNo = null;
        }

        _bookRepository.Add(book);
    }

    private string ReaderData()
    {
        var result = new string?[5];
        result[0] = $"'{Guid.NewGuid()}'";

        ConsoleHelper.Output("Введите ФИО: ");
        result[1] = $"'{ConsoleHelper.Input().Trim()}'";

        ConsoleHelper.Output("Введите номер телефона: ");
        result[2] = $"'{ConsoleHelper.Input().Trim()}'";

        ConsoleHelper.Output("Введите адрес регистрации: ");
        var address = ConsoleHelper.Input().Trim();
        if (address.Length > 0)
        {
            result[3] = $"'{address}'";
        }
        else
        {
            result[3] = NULL;
        }

        ConsoleHelper.Output("Введите возраст: ");
        var age = ConsoleHelper.Input().Trim();
        if (age.Length > 0)
        {
            result[4] = $"'{age}'";
        }
        else
        {
            result[4] = NULL;
        }

        return string.Join(", ", result);
    }
}