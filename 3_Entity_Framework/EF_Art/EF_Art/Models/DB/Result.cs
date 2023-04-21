namespace EF_Art.Models.DB;

public class Result<T>
{
    public Result()
    {
        Data = new List<T>();
        Error = null;
        QueryRequest = "";
    }

    public List<T>? Data { get; set; } = default(List<T>);
    public string? Error { get; set; }
    public string QueryRequest { get; set; } = null!;



}
