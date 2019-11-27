# challenge

## Script running
First step, is to run the script for creating and populating the database.
Open SSMS and run the scripts in the following order. Be aware, you should switch to SQLCMD mode for each script before executing (Higher menu in SSMS, click Query -> clik SQLCMD Mode).
### Create database:
1.createDb
### Create tables used:
2.CreatingRoles,CreateImageTable (for second test),CreatingUserTable
3.CreatingUserRoles
Inserting dummy data into tables:
4.InsertUsersAndRole
### Adding stored procedures:
5.DeleteUserProcedure, FIndUserByIdProcedure, GetAllRolesProcedure, GetAllUsersProcedure,
InsertIntoImagesTableProcedure, InsertRoleProcedure


## Building applications
First solution is found under Problema1 folder. There you can open a command prompt and run:
	- nuget.exe restore LoginApp.sln  used for restoring the packages
	- msbuild LoginApp.sln  used for building the applications
Second solution is found under Problema2 folder. It is split in 2 solutions Unzip and Zip. For each solution you canrun the same commands as described earlier.

### You should change the connectionStrings with your local one!

For the first solution, you can run the app under bin folder LoginApp.exe, valid credentials are U:Vlad, P:Vlad.
PS:Password is hashed in database.

For the second solution, you can firslty go to Zip solution, bin folder. There is a .exe file generated by builds. You can run this and it will create the zip file needed for the Unzip solution. Then you can go to Unzip solution, bin folder and run .exe and see the results in the database, (Image table) !