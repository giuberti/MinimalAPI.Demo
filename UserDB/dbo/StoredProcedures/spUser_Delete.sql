CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id INT
AS
begin
	DELETE
	FROM dbo.[User]
	WHERE Id = @Id;
end