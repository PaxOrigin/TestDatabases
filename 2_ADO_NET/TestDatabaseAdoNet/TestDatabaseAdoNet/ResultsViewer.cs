namespace TestDatabaseAdoNet;
public static class ResultsViewer
{
    public static void PrintResult<T>(T result)
    {
        //Console.WriteLine(result.QueryRequest);
        Console.WriteLine();
        result.PrintJson();
    }
}
