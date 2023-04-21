
BEGIN TRY
	BEGIN TRANSACTION
	CREATE TABLE [Museum]
	(
		[Id_Museum]		INT IDENTITY(1,1) NOT NULL UNIQUE,
		[MuseumName]	VARCHAR (50) NOT NULL,
		[City]			VARCHAR(30) NOT NULL,
		CONSTRAINT PK_Museum PRIMARY KEY ([Id_Museum])
	)
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Failed Museum Table Creation'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	CREATE TABLE [Artist]
	(
		[Id_Artist]		INT IDENTITY(1,1) NOT NULL,
		[Name]			VARCHAR (50) NOT NULL,
		[Country]		VARCHAR(30) NOT NULL,
		CONSTRAINT PK_Artist PRIMARY KEY ([Id_Artist])
	)
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Failed Artist Table Creation'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	CREATE TABLE [Character]
	(
		[Id_Character]		INT IDENTITY(1,1) NOT NULL UNIQUE,
		[Name]			VARCHAR (50) NOT NULL,
		CONSTRAINT PK_Character PRIMARY KEY ([Id_Character])
	)
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Failed Character Table Creation'
	ROLLBACK
END CATCH


BEGIN TRY
	BEGIN TRANSACTION
	CREATE TABLE [Artwork]
	(
		[Id_Artwork]	INT IDENTITY (1,1) NOT NULL UNIQUE,
		[Name]			VARCHAR (50) NOT NULL,
		[Id_Museum]		INT NOT NULL,
		[Id_Artist]		INT NOT NULL,
		[Id_Character]	INT,
		CONSTRAINT PK_Artwork PRIMARY KEY ([Id_Artwork]),
		CONSTRAINT FK_Artist FOREIGN KEY ([Id_Artist]) REFERENCES [Artist] ([Id_Artist]),
		CONSTRAINT FK_Museum FOREIGN KEY ([Id_Museum]) REFERENCES [Museum] ([Id_Museum]),
		CONSTRAINT FK_Character FOREIGN KEY ([Id_Character]) REFERENCES [Character] ([Id_Character])
	)
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Failed Artwork Table Creation'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO [Museum] ([MuseumName], [City])
	VALUES
	
		('Santa Maria Gloriosa dei Frari',	'Venezia'),
		('Louvre',							'Parigi'),
		('Galleria Borghese',				'Roma'),
		('Art Institute of Chicago',		'Chicago')
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Impossibile inserire i valori nella tabella museum.'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO [Artist]
	VALUES
		('Tiziano Vecellio',	'Italia'),
		('Caravaggio',			'Italia'),
		('Picasso',				'Spagna')
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Impossibile inserire i valori nella tabella artist.'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO [Character]
	VALUES
		('Flora'),
		('Davide'),
		('Chitarrista')
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Impossibile inserire i valori nella tabella Character.'
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO [Artwork]
	VALUES
		('Flora', 1, 1, 1),
		('Concerto Campestre', 2, 1, NULL),
		('Davide con la testa di Golia', 3, 2, 2),
		('Il vecchio chitarrista cieco', 4, 3, 3)
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Impossibile inserire i valori nella tabella artwork.'
	ROLLBACK
END CATCH
