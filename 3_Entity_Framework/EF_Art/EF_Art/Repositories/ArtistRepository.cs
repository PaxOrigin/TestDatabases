using EF_Art.Models.DB;

using Microsoft.EntityFrameworkCore;

namespace EF_Art.Repositories;

public interface IArtistRepository
{
    public Result<object> ExecuteQuery2(string citta);
}

public class ArtistRepository : IArtistRepository
{
    private string GetQuery3Text(string citta) => $"Scrivere una query per recuperare i nomi degli artisti, opere di quali sono conservate a {citta}";

    private ArtContext _db;

    public ArtistRepository(ArtContext db)
    {
        _db = db;
    }

    public Result<object> ExecuteQuery2(string citta)
    {
        Result<object> result = new Result<object>();
        result.QueryRequest = GetQuery3Text(citta);

        try
        {
            result.Data.AddRange
                (
                    _db.Artworks
                    .Include(p => p.IdArtistNavigation)
                    .Include(g => g.IdMuseumNavigation)
                    .Where(p => p.IdMuseumNavigation.City == citta)
                    .Select(p => new
                    {
                        ArtistName = p.IdArtistNavigation.Name
                    }
                ));
        }
        catch (Exception e)
        {
            result.Error = e.Message;
            return result;
        }
        return result;
    }
}
