IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('SourceTexts', 'u') IS NOT NULL

EXEC sp_rename 'SourceTexts.TextContent', 'SourceText', 'COLUMN';