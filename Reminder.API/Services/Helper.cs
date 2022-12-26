namespace Reminder.API.Services
{
    public static class Helper
    {
        /// <summary>
        /// Getting a database row
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}
