IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'GOST 7.79-2000',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'E', 'e',
	'YO', 'yo',
	'ZH', 'zh',
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
	'KH', 'kh',
	'TS', 'ts',
	'CH', 'ch',
	'SH', 'sh',
	'SHH', 'shh',
	'\u0022',
	'Y', 'y',
	'\u0027',
	'EH', 'eh',
	'YU', 'yu',
	'YA', 'ya'
);