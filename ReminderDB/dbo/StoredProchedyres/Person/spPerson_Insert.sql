CREATE PROCEDURE [dbo].[spPerson_Insert]
	@Name nvarchar(50),
	@LastName nvarchar(50),
	@MiddleName nvarchar(50),
	@Position nvarchar(50),
	@Birthday datetime,
	@Age int,
	@Days int,
	@Base64 text
AS

begin
	insert into dbo.[Person] (Name, LastName, MiddleName, Position, Birthday, Age, Days, Base64)
	values(@Name, @LastName, @MiddleName, @Position, @Birthday, @Age, @Days, @Base64);
end
