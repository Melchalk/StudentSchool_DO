using ConsoleOptions;
using Microsoft.Data.SqlClient;
using Provider;

namespace DbHelper.Actions;

internal class Updater : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Update;

    public Updater()
    {
        Message = "-- Выполняется обновление записи --";
        DoneMessage = "\nОбновление записи выполнено";
        _request = "UPDATE Readers SET {1} = {2} WHERE Id='{0}'";
    }

    public override string PerformAction()
    {
        if (ChoiceTable() == (int)Tables.Readers)
        {
            UpdateReader(GetID());
        }
        else
        {
            UpdateBook(GetID());
        }

        return DoneMessage;
    }

    private void UpdateReader(Guid Id)
    {
        var attribute = ChoiceReaderAttribute();

        ConsoleHelper.Output("\nВведите новое значение: ");

        var newValue = ConsoleHelper.Input();
        if (!newValue.All(char.IsDigit))
        {
            newValue = $"'{newValue}'";
        }

        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(_request, Id, attribute, newValue);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        int sqlDataReader = sqlCommand.ExecuteNonQuery();
    }

    private void UpdateBook(Guid Id)
    {
        var attribute = ChoiceBookAttribute();

        ConsoleHelper.Output("\nВведите новое значение: ");

        var newValue = ConsoleHelper.Input();

        _bookRepository.UpdateBook(Id, attribute, newValue);
    }

    private string ChoiceReaderAttribute()
    {
        var choice = "Выберите изменение:\n" +
            $"ФИО ({(int)ReaderAttributes.Fullname})\n" +
            $"Телефон ({(int)ReaderAttributes.Telephone})\n" +
            $"Адрес регистрации ({(int)ReaderAttributes.Registration_address})\n" +
            $"Возраст ({(int)ReaderAttributes.Age})\n" +
            $"Номер - ";

        ConsoleHelper.Output(choice);

        int numberAttribute = int.Parse(ConsoleHelper.Input());

        return ((ReaderAttributes)numberAttribute).ToString();
    }

    private string ChoiceBookAttribute()
    {
        var choice = "Выберите изменение:\n" +
            $"Название ({(int)BookAttributes.Title})\n" +
            $"Автор ({(int)BookAttributes.Author})\n" +
            $"Количество стр ({(int)BookAttributes.Number_pages})\n" +
            $"Дату публикации ({(int)BookAttributes.Year_publishing})\n" +
            $"Город ({(int)BookAttributes.City_publishing})\n" +
            $"Номер холла ({(int)BookAttributes.Hall_no})\n" +
            $"Номер - ";

        ConsoleHelper.Output(choice);

        int numberAttribute = int.Parse(ConsoleHelper.Input());

        return ((BookAttributes)numberAttribute).ToString();
    }
}
