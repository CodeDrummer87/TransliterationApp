IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'GOST 7.79-2000',
	'a',
	'b',
	'v',
	'g',
	'd',
	'e',
	'yo',
	'zh',	
	'z',
	'i',
	'j',
	'k',
	'l',
	'm',
	'n',
	'o',
	'p',
	'r',
	's',
	't',
	'u',
	'f',
	'kh',
	'ts',
	'ch',
	'sh',
	'shh',
	'"',
	'y',
	'&#x27',
	'eh',
	'yu',
	'ya'
);