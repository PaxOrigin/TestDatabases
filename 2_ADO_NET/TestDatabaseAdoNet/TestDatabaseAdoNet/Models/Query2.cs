using System.Text.Json.Serialization;

namespace TestDatabaseAdoNet.Models
{
    public class Query2
    {
        [JsonPropertyName("Nome Artista")]
        public string Nome { get; set; }
    }
}
