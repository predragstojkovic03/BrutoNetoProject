CREATE PROCEDURE [dbo].[GetEmployees]
AS
	BEGIN
		SELECT Id ,Name, Surname, Email, PhoneNumber, Adress, City, Neto, Bruto FROM Employee
	END
