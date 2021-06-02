CREATE PROCEDURE [dbo].[GetEmployee]
	@Id int
AS
	BEGIN
		SELECT Id, Name, Surname, Email, PhoneNumber, Adress, City, Neto, Bruto FROM Employee WHERE Id = @Id
	END

