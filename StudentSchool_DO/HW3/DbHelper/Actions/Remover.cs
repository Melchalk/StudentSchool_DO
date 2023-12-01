using DbModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Provider;

namespace DbHelper.Actions;

internal class Remover : Action
{
    public static int ID { get; private set; } = (int)DbEnum.Delete;

    public Remover()
    {
        Message = "-- Выполняется удаление записи --\n";
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
            Delete(GetID());
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

    private async Task Delete(Guid Id)
    {
        var books = await _bookRepository.GetAsync();
        DbBook book = books.FirstOrDefault(u => u.Id == Id)
            ?? throw new Exception("Book is null");

        await _bookRepository.DeleteAsync(book);
    }
}