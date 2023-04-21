using EF_Art.Models.DB;

using Microsoft.EntityFrameworkCore;

namespace EF_Art.Repositories;

public interface IMuseumRepository
{
    public Result<object> ExecuteQuery3(string artworkName);
}

public class MuseumRepository : IMuseumRepository
{
    private ArtContext _db;
    private string GetQuery3Message(string artworkName) => $"Scrivere una query “select” per recuperare la città in quale è conservato l'opera \"{artworkName}\"";

    public MuseumRepository(ArtContext db)
    {
        _db = db;
    }

    public Result<object> ExecuteQuery3(string artworkName)
    {
        var result = new Result<object>();
        try
        {
            result.QueryRequest = GetQuery3Message(artworkName);
            result.Data.AddRange(
                _db.Artworks
                .Include(p => p.IdMuseumNavigation)
                .Where(g => g.Name == artworkName)
                .Select(p => new
                {
                    Citta = p.IdMuseumNavigation.City
                }));
        }
        catch (Exception ex)
        {
            result.Error = ex.Message;
            return result;
        }
        return result;


    }
}
