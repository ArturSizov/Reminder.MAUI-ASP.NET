using SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public interface IDataProvider
    {
        SQLiteAsyncConnection DbConnection { get; set; }
    }
}