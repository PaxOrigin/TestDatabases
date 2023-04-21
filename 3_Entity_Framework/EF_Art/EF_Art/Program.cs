using EF_Art.Models.DB;
using EF_Art.Repositories;

namespace EF_Art
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ArtContext();
            IArtworkRepository _artworkRepository = new ArtworkRepository(db);
            IMuseumRepository _museumRepository = new MuseumRepository(db);
            IArtistRepository _artistRepository = new ArtistRepository(db);


            var query1Result = _artworkRepository.ExecuteQuery1();
            PrintJson.PrintResults(query1Result);

            var query2Result = _artistRepository.ExecuteQuery2("Parigi");
            PrintJson.PrintResults(query2Result);

            var query3Result = _museumRepository.ExecuteQuery3("Flora");
            PrintJson.PrintResults(query3Result);


        }
    }
}