-- Use SQLCMD mode (from SSMS Query menu) and uncomment the following settings in turn
:SETVAR dbnamestem "ironmountain"

USE $(dbnamestem)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DECLARE @USERNAME1 NVARCHAR(255) = 'Vlad'
DECLARE @USERNAME2 NVARCHAR(255) = 'Cristina'
DECLARE @PASSNAME1 NVARCHAR(255) = 'pNFyW1LAqs2vUA6E8NuR5vqCIgA='  --Vlad
DECLARE @PASSNAME2 NVARCHAR(255) = 'gJcphSEC0wI9Jpy667tVU4HVf8U=' --Cristina md5 encrypt

DECLARE @ROLENAME1 NVARCHAR(255) = 'client'
DECLARE @ROLENAME2 NVARCHAR(255) = 'dev'
DECLARE @ROLENAME3 NVARCHAR(255) = 'pm'

DELETE FROM [UserRoles];
DELETE FROM [Roles];
DELETE FROM [Users];

INSERT INTO [Roles] ([Name]) VALUES (@ROLENAME1);
INSERT INTO [Roles] ([Name]) VALUES (@ROLENAME2);
INSERT INTO [Roles] ([Name]) VALUES (@ROLENAME3);

INSERT INTO [Users] ([Name],[Password]) VALUES (@USERNAME1,@PASSNAME1);
INSERT INTO [Users] ([Name],[Password]) VALUES (@USERNAME2,@PASSNAME2);

INSERT INTO [UserRoles] ([UserId],[RoleId]) VALUES (1,1);
INSERT INTO [UserRoles] ([UserId],[RoleId]) VALUES (1,2);
INSERT INTO [UserRoles] ([UserId],[RoleId]) VALUES (2,2);

