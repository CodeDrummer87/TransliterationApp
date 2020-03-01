IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'US Department of State transliteration',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'YE', 'ye',
	'YE', 'ye',
	'ZH', 'zh',
	'Z', 'z',
	'I', 'i',
	'Y', 'y',
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
	'SHCH', 'shch',
	'',
	'Y', 'y',
	'',
	'E', 'e',
	'YU', 'yu',
	'YA', 'ya'
);