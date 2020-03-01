IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'Passport Translit (MFA (Russia) order No. 4271)',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'E', 'e',
	'E', 'e',
	'ZH', 'zh',
	'Z', 'z',
	'I', 'i',
	'I', 'i',
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
	'ie',
	'Y', 'y',
	'',
	'E', 'e',
	'IU', 'iu',
	'IA', 'ia'
);