SELECT Mus.[City]
FROM [Character] Charc
JOIN [Artwork] AWork ON Charc.[Id_Character] = AWork.[Id_Character]
JOIN [Museum] Mus ON AWork.[Id_Museum] = Mus.[Id_Museum]
WHERE Charc.[Name] = 'Flora'