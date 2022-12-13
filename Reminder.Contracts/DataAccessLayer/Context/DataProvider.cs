using Dapper;
using System.Data.SQLite;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public class DataProvider : IDataProvider
    {
        private string file = Environment.CurrentDirectory + "\\Reminder.sqlite.db";
        public SQLiteConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=" + file);
        }

        public DataProvider()
        {
            if (!File.Exists(file))
            {
                DbConnection().Open();
                DbConnection().
                    ExecuteAsync("Create Table Persons(ID int, Name nvarchar(50), LastName nvarchar(50), MiddleName nvarchar(50),Position nvarchar(50), Birthday datetime, Age int, Days int, Base64 text)");




                    //("Create Table Persons(" +
                    //"ID int, " +
                    //"Name nvarchar(50)), " +
                    //"LastName nvarchar(50), " +
                    //"MiddleName nvarchar(50), " +
                    //"Position nvarchar(50), " +
                    //"Birthday datetime, " +
                    //"Age int, " +
                    //"Days int, " +
                    //"Base64 text");
            }
        }
    }
}

