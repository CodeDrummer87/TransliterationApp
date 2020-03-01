IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'GOST 16876-71',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'E', 'e',
	'JO', 'jo',
	'ZH', 'zh',
	'Z', 'z',
	'I', 'i',
	'JJ', 'jj',
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
	'KH', 'kh',
	'C', 'c',
	'CH', 'ch',
	'SH', 'sh',
	'SHH', 'shh',
	'&#x22',
	'Y', 'y',
	'&#x27',
	'EH', 'eh',
	'JU', 'ju',
	'JA', 'ja'
);