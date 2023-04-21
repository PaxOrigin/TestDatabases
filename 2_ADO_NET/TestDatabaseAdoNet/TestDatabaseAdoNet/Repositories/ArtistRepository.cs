using Microsoft.Data.SqlClient;

using TestDatabaseAdoNet.Models;

namespace TestDatabaseAdoNet.Repositories;


public interface IArtistRepository
{
    public Result<Query2> ExecuteQuery2();
}
public class ArtistRepository : IArtistRepository
{
    private string QueryTwoMessage() => "Scrivere una query per recuperare i nomi degli artisti, opere di quali sono conservate a Parigi";

    public Result<Query2> ExecuteQuery2()
    {

        Result<Query2>? result = new();
        result.QueryRequest = QueryTwoMessage();

        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query2(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {

                result.Data!.Add(new Models.Query2()
                {
                    Nome = reader.GetString(0)
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
