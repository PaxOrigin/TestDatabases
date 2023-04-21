using Newtonsoft.Json;

namespace TestDatabaseAdoNet;

public static class JsonExtension
{
    public static void PrintJson(this object result)
    {
        var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine(resultJson);

        // Modo veloce e pigro per creare due linee vuote

    }

}
