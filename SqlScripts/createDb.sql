-- Use SQLCMD mode (from SSMS Query menu) and uncomment the following settings in turn

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DECLARE @DatabaseName NVARCHAR(255) = 'ironmountain'
USE master

IF EXISTS(select * from sys.databases where name= @DatabaseName)
BEGIN
	EXEC('DROP DATABASE ' + @DatabaseName)
END

ELSE
BEGIN
	EXEC('CREATE DATABASE ' + @DatabaseName)
END

--ALTER DATABASE @DatabaseName 
--	SET SINGLE_USER 
--	WITH ROLLBACK IMMEDIATE;
--	GO