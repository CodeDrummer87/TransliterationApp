IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
INSERT INTO Alphabets VALUES (
	'ISO 9-1995',
	'A', 'a',
	'B', 'b',
	'V', 'v',
	'G', 'g',
	'D', 'd',
	'E', 'e',
	'\u00CB', '\u00EB',
	'\u017D', '\u017E',
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
	'C', 'c',
	'\u010C', '\u010D',
	'\u0160', '\u0161',
	'\u015C', '\u015D',
	'\u0022',
	'Y', 'y',
	'\u0027',
	'\u00C8', '\u00E8',
	'\u00DB', '\u00FB',
	'\u00C2', '\u00E2'
);