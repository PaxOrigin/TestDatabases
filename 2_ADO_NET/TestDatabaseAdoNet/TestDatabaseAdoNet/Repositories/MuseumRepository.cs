using Microsoft.Data.SqlClient;

using TestDatabaseAdoNet.Models;

namespace TestDatabaseAdoNet.Repositories;

public interface IMuseumRepository
{
    public Result<Query3> ExecuteQuery3();
}
public class MuseumRepository : IMuseumRepository
{
    private string QueryThreeMessage() => "Scrivere una query “select” per recuperare la città in quale è conservato quadro \"Flora\"";

    public Result<Query3> ExecuteQuery3()
    {
        Result<Query3>? result = new Result<Query3>();
        result.QueryRequest = QueryThreeMessage();


        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query3(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {

                result.Data.Add(new Models.Query3()
                {
                    City = reader.GetString(0)
                });
            }
        }

        catch (SqlException ex)
        {
            result.Error = ex.Message;
            return result;
        }

        catch (Exception ex)
        {
            result.Error = ex.Message;
            return result;
        }

        return result;
    }
}
