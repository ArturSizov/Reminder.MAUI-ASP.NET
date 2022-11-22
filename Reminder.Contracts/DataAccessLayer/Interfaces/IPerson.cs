using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Interfaces
{
    public interface IPerson
    {
        IEnumerable<Person> FindById(int id);
    }
}
