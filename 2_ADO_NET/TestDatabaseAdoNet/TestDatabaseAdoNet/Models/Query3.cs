using System.Text.Json.Serialization;

namespace TestDatabaseAdoNet.Models;

public class Query3
{
    [JsonPropertyName("Citta'")]
    public string City { get; set; } = null!;
}
