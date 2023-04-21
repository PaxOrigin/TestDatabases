-- Museo, Nome opera, Nome personaggio, selezionare le opere che hanno artista italiano

SELECT	Mus.[MuseumName] AS 'Nome Museo', 
		Awork.[Name] AS 'Nome Opera', 
		Charc.[Name] AS 'Nome Personaggio'
FROM [Artwork] Awork
JOIN [Artist] Aist ON Awork.[Id_Artist] = Aist.[Id_Artist]
LEFT JOIN [Character] Charc ON  Awork.[Id_Character] = Charc.[Id_Character]
JOIN [Museum] Mus ON Awork.[Id_Museum] = Mus.[Id_Museum]
WHERE Aist.[Country] = 'Italia'