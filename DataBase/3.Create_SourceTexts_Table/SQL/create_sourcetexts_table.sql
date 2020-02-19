IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('SourceTexts', 'u') IS NULL
CREATE TABLE SourceTexts
(
	TextId INT IDENTITY (1, 1) PRIMARY KEY,
	TextName NVARCHAR(50),
	TextDescription NVARCHAR(200),
	SourceText NVARCHAR(MAX)
);