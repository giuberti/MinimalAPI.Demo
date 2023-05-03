CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	INSERT into dbo.[User] (FirstName, LastName)
	VALUES (@FirstName, @LastName);
end