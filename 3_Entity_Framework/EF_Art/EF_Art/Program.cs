using EF_Art.Models.DB;
using EF_Art.Repositories;

namespace EF_Art
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IArtworkRepository artworkRepository = new ArtworkRepository();
            var db = new ArtContext();
            Console.WriteLine(artworkRepository.ExecuteQuery1(db));

        }
    }
}