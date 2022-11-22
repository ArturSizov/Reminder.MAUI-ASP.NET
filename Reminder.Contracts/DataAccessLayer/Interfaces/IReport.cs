using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Interfaces
{
    public interface IReport
    {
        IEnumerable<Report> FindById(int id);
    }
}
