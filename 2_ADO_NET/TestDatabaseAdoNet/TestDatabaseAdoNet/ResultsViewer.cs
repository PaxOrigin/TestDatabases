using TestDatabaseAdoNet.Models;

namespace TestDatabaseAdoNet;
public static class ResultsViewer
{
    public static void PrintResult<T>(Result<T> result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result.QueryRequest);
        Console.ResetColor();
        if (result.Data!.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Nessun Risultato trovato");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Errore trovato: {result.Error}");
        }
        else
        {
            Console.WriteLine();
            result.Data.PrintJson();
        }
        Console.WriteLine();
        Console.WriteLine();

    }
}
