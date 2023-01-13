using Reminder.Contracts.Models;
using System.Collections.ObjectModel;

namespace Reminder.Interfaces
{
    public interface IRepository
    {
        Task<List<Person>> GetPersons();
        ObservableCollection<Person> Persons { get; set; }
        Task InsertPerson(Person person); 
        Task DeletePerson(Person person);
        Task UpdatePerson(Person person);
    }
}
