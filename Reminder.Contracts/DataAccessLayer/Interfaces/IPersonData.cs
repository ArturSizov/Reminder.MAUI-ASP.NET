using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Interfaces
{
    public interface IPersonData
    {
        string? DatabasePath { get; set; }
        Task DeletePerson(Person person);
        Task<Person?> GetPerson(int id);
        Task<List<Person>> GetPersons();
        Task InsertPerson(Person person);
        Task UpdatePerson(Person person);
    }
}