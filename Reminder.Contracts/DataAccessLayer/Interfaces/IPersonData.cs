using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Interfaces
{
    public interface IPersonData
    {
        Task DeletePerson(Person person);
        Task<Person?> GetPerson(int id);
        Task<IEnumerable<Person>> GetPersons();
        Task InsertPerson(Person person);
        Task UpdatePerson(Person person);
    }
}