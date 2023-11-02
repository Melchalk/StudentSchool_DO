using DBModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class UserRepository
{
    private readonly OfficeDB _dbContext = new();

    private const string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Less;Trusted_Connection=True;Encrypt=False;";
    private const string GetUsersSQL = @"SELECT * FROM Users";
    private const string GetUserSQL =
        @"SELECT * FROM Users
        WHERE id = '{0}'";

    public List<DBUser> GetUsersEF()
    {
        return _dbContext.Users.ToList();
    }

    public DBUser GetUserEF(Guid userId)
    {
        return _dbContext.Users
            .Where(u => u.id == userId)
            .FirstOrDefault();
    }

    public void CreateUser(DBUser user)
    {
        _dbContext.Users.Add(user);

        _dbContext.SaveChanges();
    }

    public void EditUser(Guid userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.id == userId);

        user.FirstName = "NEW_NAME";

        _dbContext.SaveChanges();
    }

    public void DeleteUser(Guid userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.id == userId);

        _dbContext.Remove(user);

        _dbContext.SaveChanges();
    }

    public string GetUsersFromDB()
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);
        var sqlCommand = new SqlCommand(GetUsersSQL, sqlConnection);

        sqlConnection.Open();
        using var sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            result += sqlDataReader["id"];
            result += " ";
            result += sqlDataReader["FirstName"];
            result += " ";
            result += sqlDataReader["LastName"];
            result += "\n";
        }

        return result;
    }

    public string GetUser(Guid userId)
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(GetUserSQL, userId);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        using var sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            result += sqlDataReader["id"];
            result += " ";
            result += sqlDataReader["FirstName"];
            result += " ";
            result += sqlDataReader["LastName"];
        }

        return result;
    }
}
