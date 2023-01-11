using SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public interface IDataProvider
    {
        public SQLiteAsyncConnection Database { get; set; }
        public Task Init(string databasePath);
    }
}