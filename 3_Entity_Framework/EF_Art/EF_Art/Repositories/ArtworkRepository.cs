using EF_Art.Models.DB;

using Microsoft.EntityFrameworkCore;

namespace EF_Art.Repositories;

public interface IArtworkRepository
{
    public Result<object> ExecuteQuery1();
}
public class ArtworkRepository : IArtworkRepository
{
    private string QueryOneText() => "Scrivere una query \"select\" per recuperare la lista contenete: museo, nome opera, nome \r\npersonaggio degli artisti italiani";

    private ArtContext _db;

    public ArtworkRepository(ArtContext db)
    {
        _db = db;
    }

    public Result<object> ExecuteQuery1()
    {
        Result<object> result = new Result<object>();
        result.QueryRequest = QueryOneText();
        try
        {
            result.Data!.AddRange(_db.Artworks
                .Include(p => p.IdMuseumNavigation)
                .Include(d => d.IdArtistNavigation)
                .Include(g => g.IdCharacterNavigation)
                .Where(g => g.IdArtistNavigation.Country == "Italia")
                .Select(p => new
                {
                    MuseumName = p.IdMuseumNavigation.MuseumName,
                    ArtistName = p.Name,
                    CharacterName = p.IdCharacterNavigation.Name ?? "Null"
                }
                ));


        }
        catch (Exception ex)
        {
            result.Error = ex.Message;
            return result;
        }
        return result;
    }
}
