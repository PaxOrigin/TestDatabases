using EF_Art.Models.DB;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace EF_Art.Repositories;

public interface IArtworkRepository
{
    public string ExecuteQuery1(ArtContext db);
}
public class ArtworkRepository : IArtworkRepository
{
    public string ExecuteQuery1(ArtContext db)
    {
        string? result;
        try
        {
            var resultNotJson = db.Artworks
                .Include(p => p.IdMuseumNavigation)
                .Include(d => d.IdArtistNavigation)
                .Include(g => g.IdCharacterNavigation)
                .Where(g => g.IdArtistNavigation.Country == "Italia")
                .Select(p => new
                {
                    MuseumName = p.IdMuseumNavigation.MuseumName,
                    ArtworkName = p.Name,
                    CharacterName = p.IdCharacterNavigation.Name
                }).ToList();

            result = JsonConvert.SerializeObject(resultNotJson, Formatting.Indented);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        return result;
    }
}
