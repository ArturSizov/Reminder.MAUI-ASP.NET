using Dapper;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using System.Data;
using System.Reflection.Metadata;

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

        public Task<Person?> GetPerson(int id)
        {
            throw new NotImplementedException();
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

        public Task UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
