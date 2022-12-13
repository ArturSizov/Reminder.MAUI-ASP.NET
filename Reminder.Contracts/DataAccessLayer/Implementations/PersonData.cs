using Dapper;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Implementations
{
    public class PersonData : IPersonData
    {
        private readonly IDataProvider data;

        public PersonData(IDataProvider data)
        {
            this.data = data;
        }

        public async Task DeletePerson(int id)
        {
            await data.DbConnection.ExecuteAsync("delete from persons where id=@ID", new { ID = id });
        }

        public async Task<Person?> GetPerson(int id)
        {
            var person = await data.DbConnection.QueryAsync<Person>("select id, name, lastName, middleName, position, " +
                "birthday, age, days, base64 from Persons where ID = @Id", new { id });
           return person.FirstOrDefault();
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            var list = await data.DbConnection.QueryAsync<Person>("select * from Persons");
            return list;
        }

        public async Task InsertPerson(Person person)
        {
            await data.DbConnection.ExecuteAsync("insert into persons(name,lastname,middleName,position,birthday,age,days,base64)" +
                "values(@Name,@LastName,@MiddleName,@Position,@Birthday,@Age,@Days,@Base64)", 
            new 
            {
                person.Name,
                person.LastName,
                person.MiddleName,
                person.Position,
                person.Age,
                person.Days,
                person.Birthday,
                person.Base64
            });
        }

        public async Task UpdatePerson(Person person)
        {
            await data.DbConnection.ExecuteAsync("update persons set name=@Name, lastName=@LastName, middleName=@MiddleName, position=@Position, birthday=@Birthday, age =@Age, days=@Days, base64=@Base64 where id = @Id",
                new
                {   
                    id = person.Id,
                    name = person.Name,
                    lastName = person.LastName,
                    middleName = person.MiddleName,
                    position = person.Position,
                    age = person.Age,
                    days = person.Days,
                    birthday = person.Birthday,
                    base64 = person.Base64
                });
        }
    }
}
