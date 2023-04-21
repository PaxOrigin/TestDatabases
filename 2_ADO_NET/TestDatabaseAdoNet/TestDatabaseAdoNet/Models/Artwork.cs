namespace TestDatabaseAdoNet.Models;

public class Artwork
{
    public int Id { get; set; } = 0!;
    public string Name { get; set; } = null!;
    public Artist ArtworkArtist { get; set; } = null!;
    public Museum ArtworkMuseum { get; set; } = null!;
    public Character? ArtworkCharacter { get; set; }
}
