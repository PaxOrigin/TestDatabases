using EF_Art.Models.DB;

using Newtonsoft.Json;

namespace EF_Art;

public static class PrintJson
{
    public static void PrintResults<T>(Result<T> result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result.QueryRequest);
        Console.WriteLine();
        Console.WriteLine();
        Console.ResetColor();

        if (result.Data.Count == 0)
        {
            Console.WriteLine("Nessun risultato trovato!");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("errore riscontrato: " + result.Error);
        }
        else
        {
            Console.WriteLine(JsonConvert.SerializeObject(result.Data, Formatting.Indented));
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
