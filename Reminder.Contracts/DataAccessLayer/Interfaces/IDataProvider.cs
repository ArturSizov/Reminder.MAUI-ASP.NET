using System.Data.SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public interface IDataProvider
    {
        SQLiteConnection DbConnection { get; set; }
    }
}