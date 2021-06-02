CREATE PROCEDURE [dbo].[CreateEmployee]

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
		INSERT INTO Employee(Name, Surname, Email, PhoneNumber, Adress, City, Neto, Bruto)
		VALUES (@Name, @Surname, @Email, @PhoneNumber, @Adress, @City, @Neto, @Bruto)
	END

