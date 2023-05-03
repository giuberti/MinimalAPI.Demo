CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	SELECT Id, FirstName, LastName
	FROM dbo.[User];
end
