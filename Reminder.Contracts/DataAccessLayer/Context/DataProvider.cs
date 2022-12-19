using Reminder.Contracts.Models;
using SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public class DataProvider : IDataProvider
    {
        private string? file;

        public SQLiteAsyncConnection DbConnection { get; set; }

        public DataProvider()
        {
            SetUpDb();
        }

        #region Methods
        private async void SetUpDb()
        {
            if (DbConnection == null)
            {
                file = GetDatabasePath("Reminder.sqlite.db");
                DbConnection = new SQLiteAsyncConnection(file);
                await DbConnection.CreateTableAsync<Person>();
            }
        }
        private string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
        #endregion
    }
}

