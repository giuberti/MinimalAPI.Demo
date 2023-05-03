CREATE PROCEDURE [dbo].[spUser_Get]
	@Id INT
AS
begin
	SELECT Id, FirstName, LastName
	FROM dbo.[User]
	WHERE Id = @Id;
end
