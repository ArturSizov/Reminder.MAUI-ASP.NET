CREATE PROCEDURE [dbo].[spPersonGet]
	@Id int
AS
begin
	select Id, Name, LastName, MiddleName, Position, Birthday, Age, Days, Base64
	from dbo.[Person]
	where Id = @Id;
end
