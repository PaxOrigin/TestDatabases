using Microsoft.Data.SqlClient;

using TestDatabaseAdoNet.Models;

namespace TestDatabaseAdoNet.Repositories;


public interface IArtistRepository
{
    public List<Query2> ExecuteQuery2();
}
public class ArtistRepository : IArtistRepository
{
    public List<Query2> ExecuteQuery2()
    {
        List<Query2>? query = new List<Query2>();

        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query2(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {

                query.Add(new Models.Query2()
                {
                    Nome = reader.GetString(0)
                });
            }
        }

        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            return query;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return query;
        }

        return query;
    }
}
