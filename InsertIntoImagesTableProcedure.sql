CREATE PROCEDURE [InsertImage]
    @Id int = null,
	@Date varchar(255),
	@Path varchar(255)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
	Insert into [Images] ([Id],[Date],[Path]) VALUES (@Id,@Date,@Path)
END