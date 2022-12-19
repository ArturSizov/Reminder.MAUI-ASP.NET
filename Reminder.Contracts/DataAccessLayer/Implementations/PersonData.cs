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

        public async Task DeletePerson(Person person)
        {
            await data.DbConnection.DeleteAsync(person);
        }

        public async Task<Person?> GetPerson(int id)
        {
            return await data.DbConnection.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await data.DbConnection.Table<Person>().ToListAsync();
        }

        public async Task InsertPerson(Person person)
        {
            await data.DbConnection.InsertAsync(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await data.DbConnection.UpdateAsync(person);
        }
    }
}
