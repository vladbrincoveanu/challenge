CREATE PROCEDURE [DeleteUser]
    @UserId int = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Users] 
	WHERE UserId = @UserId;
END