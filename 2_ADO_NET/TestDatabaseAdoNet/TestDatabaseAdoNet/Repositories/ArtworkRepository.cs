namespace TestDatabaseAdoNet.Repositories;

using Microsoft.Data.SqlClient;

using System.Data;

using TestDatabaseAdoNet.Models;

public interface IArtworkRepository
{
    public List<Query1> ExecuteQuery1();
}

public class ArtworkRepository : IArtworkRepository
{
    private string QueryOneMessage() => "Scrivere una query \"select\" per recuperare la lista contenete: museo, nome opera, nome \r\npersonaggio degli artisti italiani";
    public List<Query1> ExecuteQuery1()
    {
        Result<Query1> result = new();
        result.Data = new List<Query1>();
        result.QueryRequest = QueryOneMessage();
        List<Query1>? query = new List<Query1>();

        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query1(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader?.Read() == true)
            {
                var museumName = reader.GetString("Nome Museo");
                var artworkName = reader.GetString("Nome Opera");
                string characterName;
                if (reader.IsDBNull("Nome Personaggio"))
                {
                    characterName = "null";
                }
                else
                {
                    characterName = reader.GetString("Nome Personaggio");
                }

                query.Add(new Models.Query1()
                {
                    MuseumName = museumName,
                    ArtworkName = artworkName,
                    CharacterName = characterName
                });
            }
        }

        catch (SqlException ex)
        {
            result.Error = ex.Message;
            return query;
        }

        catch (Exception ex)
        {
            result.Error = ex.Message;
            return query;
        }

        return query;
    }
}
