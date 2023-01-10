using Reminder.Contracts.Models;
using SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public class DataProvider : IDataProvider
    {
        private readonly string fileDb;

        public SQLiteAsyncConnection DbConnection { get; set; }

        public DataProvider(string fileDb)
        {
            this.fileDb = fileDb;

            SetUpDb();
        }

        #region Methods
        /// <summary>
        /// Database initialization
        /// </summary>
        private async void SetUpDb()
        {
            if (DbConnection == null)
            {
                DbConnection = new SQLiteAsyncConnection(fileDb);
                await DbConnection.CreateTableAsync<Person>();
            }
        }
        #endregion
    }
}

