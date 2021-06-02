CREATE PROCEDURE [dbo].[DeleteEmployee]
	@Id int
AS
	BEGIN
		DELETE FROM Employee WHERE Id = @Id
	END
