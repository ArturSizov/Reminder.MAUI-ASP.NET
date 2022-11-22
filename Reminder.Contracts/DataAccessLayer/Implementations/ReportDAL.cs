using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;

namespace Reminder.Contracts.DataAccessLayer.Implementations
{
    public class ReportDAL : IReport
    {
        public IEnumerable<Report> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
