-- Use SQLCMD mode (from SSMS Query menu) and uncomment the following settings in turn

:SETVAR dbnamestem "ironmountain"
:SETVAR tablename "[UserRoles]"

USE $(dbnamestem)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'$(tablename)') AND type = N'U')
BEGIN

	CREATE TABLE [UserRoles](
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE,
    [RoleId] INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleId) ON DELETE CASCADE ON UPDATE CASCADE)

	ALTER TABLE [UserRoles]
    ADD CONSTRAINT [Id] PRIMARY KEY ([UserId],[RoleId])
END

ELSE
BEGIN
	DROP TABLE $(tablename);
END