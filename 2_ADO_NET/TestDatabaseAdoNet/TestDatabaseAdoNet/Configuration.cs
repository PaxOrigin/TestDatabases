namespace TestDatabaseAdoNet
{
    public static class Configuration
    {
        public static string ConnectionString() => @"Data Source=PAX;Initial Catalog=Art;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static string Query1() => "SELECT Mus.[MuseumName] AS 'Nome Museo', Awork.[Name] AS 'Nome Opera', Charc.[Name] AS 'Nome Personaggio' FROM [Artwork] Awork JOIN [Artist] Aist ON Awork.[Id_Artist] = Aist.[Id_Artist] LEFT JOIN [Character] Charc ON  Awork.[Id_Character] = Charc.[Id_Character] JOIN [Museum] Mus ON Awork.[Id_Museum] = Mus.[Id_Museum] WHERE Aist.[Country] = 'Italia'";

        public static string Query2() => "SELECT Aist.[Name] FROM [Artist] Aist JOIN [Artwork] Awork ON Aist.[Id_Artist] = Awork.[Id_Artist] JOIN [Museum] Mus ON Awork.[Id_Museum] = Mus.[Id_Museum] WHERE Mus.City = 'Parigi'";

        public static string Query3() => "SELECT Mus.[City] FROM [Character] Charc JOIN [Artwork] AWork ON Charc.[Id_Character] = AWork.[Id_Character] JOIN [Museum] Mus ON AWork.[Id_Museum] = Mus.[Id_Museum] WHERE Charc.[Name] = 'Flora'";
    }
}
