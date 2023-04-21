namespace TestDatabaseAdoNet.Repositories;

using Microsoft.Data.SqlClient;

using TestDatabaseAdoNet.Models;

public interface IArtworkRepository
{
    public Result<Query1> ExecuteQuery1();
}

public class ArtworkRepository : IArtworkRepository
{
    private string QueryOneMessage() => "Scrivere una query \"select\" per recuperare la lista contenete: museo, nome opera, nome \r\npersonaggio degli artisti italiani";
    public Result<Query1> ExecuteQuery1()
    {
        Result<Query1> result = new();
        result.QueryRequest = QueryOneMessage();


        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query1(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader?.Read() == true)
            {


                result.Data!.Add(new Models.Query1()
                {
                    MuseumName = reader.GetString(0),
                    ArtworkName = reader.GetString(1),
                    CharacterName = reader.IsDBNull(2) ? "null"
                                    : reader.GetString(2)
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
