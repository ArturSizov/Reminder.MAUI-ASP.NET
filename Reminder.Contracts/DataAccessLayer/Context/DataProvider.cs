using Dapper;
using System.Data.SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public class DataProvider : IDataProvider
    {
        private string file = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Reminder.sqlite.db";

        public SQLiteConnection DbConnection { get; set; }

        public DataProvider()
        {
            DbConnection = new SQLiteConnection("Data Source=" + file);

            if (!File.Exists(file))
            {
                DbConnection.Open();
                DbConnection.
                    ExecuteAsync("Create Table Persons" +
                    "(ID INTEGER PRIMARY KEY, " +
                    "Name nvarchar(50), " +
                    "LastName nvarchar(50), " +
                    "MiddleName nvarchar(50)," +
                    "Position nvarchar(50), " +
                    "Birthday datetime, " +
                    "Age int, " +
                    "Days int, " +
                    "Base64 text)");
            }
        }
    }
}

