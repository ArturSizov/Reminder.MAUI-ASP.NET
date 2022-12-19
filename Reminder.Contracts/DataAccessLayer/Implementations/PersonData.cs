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

        /// <summary>
        /// Delete method from the database
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task DeletePerson(Person person)
        {
            await data.DbConnection.DeleteAsync(person);
        }

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> method
        public async Task<Person?> GetPerson(int id)
        {
            return await data.DbConnection.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await data.DbConnection.Table<Person>().ToListAsync();
        }

        /// <summary>
        /// Insert person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task InsertPerson(Person person)
        {
            await data.DbConnection.InsertAsync(person);
        }

        /// <summary>
        /// Update person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePerson(Person person)
        {
            await data.DbConnection.UpdateAsync(person);
        }
    }
}
