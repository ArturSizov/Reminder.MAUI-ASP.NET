if not exists (select 1 from dbo.[Person])

begin
	insert into dbo.[Person] (MiddleName, LastName)
	values('Artur', 'Sizov');
end