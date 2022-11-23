CREATE PROCEDURE [dbo].[spPerson_GetAll]

AS
begin
	select Id, Name, LastName, MiddleName, Position, Birthday, Age, Days, Base64
	from dbo.[Person];
end
