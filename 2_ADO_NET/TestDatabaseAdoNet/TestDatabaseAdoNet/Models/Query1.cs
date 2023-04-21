using System.Text.Json.Serialization;

namespace TestDatabaseAdoNet.Models;


public class Query1
{
    [JsonPropertyName("Museum Name")]
    public string MuseumName { get; set; } = null!;
    [JsonPropertyName("Artwork Name")]
    public string ArtworkName { get; set; } = null!;
    [JsonPropertyName("Character Name")]
    public string? CharacterName { get; set; } = null!;
}
