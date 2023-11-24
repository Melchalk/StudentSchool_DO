using DbModels;
using Microsoft.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DbHelper.Actions;

internal class Reader : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Read;

    public Reader()
    {
        Message = "-- Выполняется чтение записи --\n";
        DoneMessage = "Искомая запись:";
        _request = @"SELECT * FROM Readers WHERE Id = '{0}'";
    }

    public override string PerformAction()
    {
        string resultOfRead;

        if (ChoiceTable() == (int)Tables.Readers)
        {
            resultOfRead = ReadReader(GetID());
        }
        else
        {
            resultOfRead = ReadBook(GetID());
        }

        return $"{DoneMessage} {resultOfRead}";
    }

    private string ReadReader(Guid Id)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(_request, Id);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        using var sqlDataReader = sqlCommand.ExecuteReader();

        string result = string.Empty;
        while (sqlDataReader.Read())
        {
            result = $"{sqlDataReader["Id"]} {sqlDataReader["Fullname"]} {sqlDataReader["Telephone"]} " +
            $"{sqlDataReader["RegistrationAddress"]} {sqlDataReader["Age"]}";
        }

        return result;
    }

    private string ReadBook(Guid Id)
    {
        DbBook? book = _bookRepository.Get(Id);

        StringBuilder infoOfBook = new();

        foreach (PropertyInfo prop in typeof(DbBook).GetProperties())
        {
            if (prop.Name != "IssueBooks")
                infoOfBook.Append($"{prop.GetValue(book)}\n");
        }


        return infoOfBook.ToString();
    }
}