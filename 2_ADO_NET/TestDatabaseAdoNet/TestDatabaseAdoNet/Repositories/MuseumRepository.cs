using Microsoft.Data.SqlClient;

using TestDatabaseAdoNet.Models;

namespace TestDatabaseAdoNet.Repositories;

public interface IMuseumRepository
{
    public List<Query3> ExecuteQuery3();
}
public class MuseumRepository : IMuseumRepository
{
    public List<Query3> ExecuteQuery3()
    {
        List<Query3>? query = new List<Query3>();

        try
        {
            using var connection = new SqlConnection(Configuration.ConnectionString());
            using var command = new SqlCommand(Configuration.Query3(), connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {

                query.Add(new Models.Query3()
                {
                    City = reader.GetString(0)
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
