using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Implementations
{
    public class PersonDAL : IPerson
    {
        public IEnumerable<Person> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
