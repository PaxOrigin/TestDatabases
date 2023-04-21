-- Artisti le cui opere sono conservate a parigi

SELECT Aist.[Name]
FROM [Artist] Aist
JOIN [Artwork] Awork ON Aist.[Id_Artist] = Awork.[Id_Artist]
JOIN [Museum] Mus ON Awork.[Id_Museum] = Mus.[Id_Museum]
WHERE Mus.City = 'Parigi'