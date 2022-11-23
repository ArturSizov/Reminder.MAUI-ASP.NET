CREATE PROCEDURE [dbo].[spPerson_Update]
	@Id int,
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
	update dbo.[Person]
	set Name = @Name, LastName = @LastName, MiddleName = @MiddleName, Position = @Position, Birthday = @Birthday, Age = @Age, Days = @Days, Base64 = @Base64
	where @Id = Id;
end
