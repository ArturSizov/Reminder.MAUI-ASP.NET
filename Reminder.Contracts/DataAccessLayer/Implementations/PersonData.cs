using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Implementations
{
    public class PersonData : IPersonData
    {
        private readonly ISqlDataAccess _db;

        public PersonData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Loading all persons from the database
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Person>> GetPersons() => _db.LoadData<Person, dynamic>("dbo.spPerson_GetAll", new { });

        /// <summary>
        /// Returning a person from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person?> GetPerson(int id)
        {
            var results = await _db.LoadData<Person, dynamic>("dbo.spPersonGet", new { Id = id });

            return results.FirstOrDefault();
        }

        /// <summary>
        /// Adding a person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task InsertPerson(Person person) => _db.SaveData("dbo.spPerson_Insert",
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

        /// <summary>
        /// Persona update
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task UpdatePerson(Person person) => _db.SaveData("dbo.spPerson_Update", person);

        /// <summary>
        /// Delete persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeletePerson(int id) => _db.SaveData("dbo.spPerson_Delete", new { Id = id });
    }
}
