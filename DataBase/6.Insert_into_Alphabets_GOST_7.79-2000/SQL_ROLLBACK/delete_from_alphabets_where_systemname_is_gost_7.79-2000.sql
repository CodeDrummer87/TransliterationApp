IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
USE TransliterationSystem;

GO

IF OBJECT_ID('Alphabets', 'u') IS NOT NULL
DELETE Alphabets WHERE SystemName = 'GOST 7.79-2000';