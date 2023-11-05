using Microsoft.Data.SqlClient;
using Provider;

namespace DbHelper.Actions;

internal class Remover : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Delete;

    public Remover()
    {
        Message = "-- Выполняется удаление записи --";
        DoneMessage = "\nУдаление записи выполнено";
        _request = @"DELETE FROM Readers WHERE Id='{0}'";
    }

    public override string PerformAction()
    {
        if (ChoiceTable() == (int)Tables.Readers)
        {
            DeleteReader(GetID());
        }
        else
        {
            DeleteBook(GetID());
        }

        return DoneMessage;
    }

    private void DeleteReader(Guid Id)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(_request, Id);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        int sqlDataReader = sqlCommand.ExecuteNonQuery();
    }

    private void DeleteBook(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }
}