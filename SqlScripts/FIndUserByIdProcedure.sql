CREATE PROCEDURE [SaveUser]
    @UserName nvarchar(255), 
	@UserPassword nvarchar(255),
	@RoleName varchar(MAX) = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Users] ([Name],[Password])
	VALUES (@UserName,@UserPassword)

	declare @i int

	while( @i < LEN(@RoleName))
	begin
		declare @RName varchar(255)
		SELECT  @RName = SUBSTRING(@RoleName,  @i,CHARINDEX(',',@RoleName,@i)-@i)
		select @RName
			exec [InsertRole] @RName
		set @i = CHARINDEX(',',@RoleName,@i)+1
		if(@i = 0) set @i = LEN(@RoleName) 
	end
	
END