using TestDatabaseAdoNet.Models;
using TestDatabaseAdoNet.Repositories;

namespace TestDatabaseAdoNet;

public class Program
{
    static void Main(string[] args)
    {
        // Perso tanto tempo perche' mi ero dimenticato della condizione del fallimento con reader che legge colonna con valore null.
        // Non sono riuscito ad implementare il tutto usando la classe Result in Models.

        IArtworkRepository artworkRepository = new ArtworkRepository();
        IArtistRepository artistRepository = new ArtistRepository();
        IMuseumRepository museumRepository = new MuseumRepository();

        var resultQuery1 = artworkRepository.ExecuteQuery1();
        ResultsViewer.PrintResult<Query1>(resultQuery1);

        var resultQuery2 = artistRepository.ExecuteQuery2();
        ResultsViewer.PrintResult<Query2>(resultQuery2);

        var resultQuery3 = museumRepository.ExecuteQuery3();
        ResultsViewer.PrintResult<Query3>(resultQuery3);


    }
}