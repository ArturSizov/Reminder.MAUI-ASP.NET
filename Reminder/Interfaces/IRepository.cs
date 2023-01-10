using Reminder.Contracts.Models;
using System.Collections.ObjectModel;

namespace Reminder.Interfaces
{
    public interface IRepository
    {
        public ObservableCollection<Person> Persons { get; set; }
    }
}
