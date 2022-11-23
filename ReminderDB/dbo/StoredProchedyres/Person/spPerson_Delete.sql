CREATE PROCEDURE [dbo].[spPerson_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Person]
	where Id = @Id;
end
