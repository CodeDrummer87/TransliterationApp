USE master

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'TransliterationSystem'))
CREATE DATABASE TransliterationSystem