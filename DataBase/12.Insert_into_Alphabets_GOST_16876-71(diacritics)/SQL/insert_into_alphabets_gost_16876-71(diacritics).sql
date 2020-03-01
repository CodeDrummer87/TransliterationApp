IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'GOST 16876-71 (diacritics)',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'E', 'e',
	'&#x00CB', '&#x00EB',
	'&#x017D', '&#x017E',
	'Z', 'z',
	'I', 'i',
	'J', 'j',
	'K', 'k',
	'L', 'l',
	'M', 'm',
	'N', 'n',
	'O', 'o',
	'P', 'p',
	'R', 'r',
	'S', 's',
	'T', 't',
	'U', 'u',
	'F', 'f',
	'H', 'h',
	'c', 'c',
	'&#x010C', '&#x010D',
	'&#x0160', '&#x0161',
	'&#x015C', '&#x015D',
	'&#x22',
	'Y', 'y',
	'&#x27',
	'&#x00C8', '&#x00E8',
	'&#x00DB', '&#x00FB',
	'&#x00C2', '&#x00E2'
);