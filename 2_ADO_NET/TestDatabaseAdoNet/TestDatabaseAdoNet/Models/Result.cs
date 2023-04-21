namespace TestDatabaseAdoNet.Models;

public class Result<T>
{
    public Result()
    {
        Data = new List<T>();
        QueryRequest = "";
    }

    public List<T>? Data { get; set; }
    public string QueryRequest { get; set; } = null!;
    public string? Error { get; set; } = null!;

    public void PrintErrors()
    {
        Console.WriteLine(Error);
    }

}
