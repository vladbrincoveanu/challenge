-- Use SQLCMD mode (from SSMS Query menu) and uncomment the following settings in turn

:SETVAR dbnamestem "ironmountain"
:SETVAR tablename "[Roles]"

USE $(dbnamestem)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'$(tablename)') AND type = N'U')
BEGIN

	CREATE TABLE [Roles](
		[RoleId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[Name] [nvarchar](255) NOT NULL)
END

ELSE
BEGIN
	DROP TABLE $(tablename);
END