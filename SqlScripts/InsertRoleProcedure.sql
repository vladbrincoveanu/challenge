CREATE PROCEDURE [InsertRole]
    @RoleName nvarchar(255) = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into [Roles] ([Name]) VALUES (@RoleName)
END