CREATE PROCEDURE [dbo].[EditEmployee]
	@Id int,
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Email nvarchar(320),
	@PhoneNumber varchar(50),
	@Adress nvarchar(100),
	@City nvarchar(66),
	@Neto decimal(9,2),
	@Bruto decimal(9,2)

AS
	BEGIN
		UPDATE Employee
		SET Name = @Name, Surname = @Surname, Email = @Email, PhoneNumber = @PhoneNumber, Adress = @Adress, City = @City, Neto = @Neto, Bruto = @Bruto
	END
