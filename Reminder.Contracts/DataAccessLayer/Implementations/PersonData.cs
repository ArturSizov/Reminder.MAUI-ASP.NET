using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using SQLite;

namespace Reminder.Contracts.DataAccessLayer.Implementations
{
    public class PersonData : IPersonData
    {
        private readonly IDataProvider data;

        public string? DatabasePath { get; set; }

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
            await data.Init(DatabasePath);
            await data.Database.DeleteAsync(person);
        }

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> method
        public async Task<Person?> GetPerson(int id)
        {
            await data.Init(DatabasePath);
            return await data.Database.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPersons()
        {
            //await data.Init(DatabasePath);
            var Database = new SQLiteAsyncConnection(DatabasePath);
            await Database.CreateTableAsync<Person>();
            return await data.Database.Table<Person>().ToListAsync();
        }

        /// <summary>
        /// Insert person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task InsertPerson(Person person)
        {
            await data.Init(DatabasePath);
            await data.Database.InsertAsync(person);
        }

        /// <summary>
        /// Update person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePerson(Person person)
        {
            await data.Init(DatabasePath);
            await data.Database.UpdateAsync(person);
        }
    }
}
