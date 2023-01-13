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
            if (DatabasePath is not null)
            {
                await data.Init(DatabasePath);
                await data.Database.DeleteAsync(person);
            }         
        }

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> method
        public async Task<Person?> GetPerson(int id)
        {
            if(DatabasePath is not null)
            {
                await data.Init(DatabasePath);
                return await data.Database.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            return new Person();
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPersons()
        {
            if (DatabasePath is not null)
            {
                await data.Init(DatabasePath);
                return await data.Database.Table<Person>().ToListAsync();
            }
            return new List<Person>();
        }

        /// <summary>
        /// Insert person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task InsertPerson(Person person)
        {
            if(DatabasePath is not null)
            {
                await data.Init(DatabasePath);
                await data.Database.InsertAsync(person);
            }
        }

        /// <summary>
        /// Update person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePerson(Person person)
        {
            if(DatabasePath is not null)
            {
                await data.Init(DatabasePath);
                await data.Database.UpdateAsync(person);
            }
        }
    }
}
