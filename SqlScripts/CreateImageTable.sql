-- Use SQLCMD mode (from SSMS Query menu) and uncomment the following settings in turn

:SETVAR dbnamestem "ironmountain"
:SETVAR tablename "[Images]"

USE $(dbnamestem)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'$(tablename)') AND type = N'U')
BEGIN

	CREATE TABLE [Images](
		[Id] [int] PRIMARY KEY NOT NULL,
		[Date] [nvarchar](255) NOT NULL,
		[Path] [nvarchar](255) NOT NULL)
END
ELSE
BEGIN
	DROP TABLE $(tablename);
END