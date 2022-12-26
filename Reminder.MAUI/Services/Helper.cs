using Reminder.Contracts.Models;
using System.Collections.Specialized;

namespace Reminder.MAUI.Services
{
    public static class Helper
    {
        /// <summary>
        /// Add image method
        /// </summary>
        /// <param name="person"></param>
        public async static Task<FileResult> AddImage(Person person)
        {
            PickOptions options = new()
            {
                PickerTitle = "Выберите файл фотографии",
                FileTypes = FilePickerFileType.Images
            };
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    var image = File.ReadAllBytes(result.FullPath);

                    person.Base64 = Convert.ToBase64String(image);
                }

                return result;
            }
            catch (Exception) { }

            return null;
        }

        /// <summary>
        /// Calculate the timing
        /// </summary>
        public static void CalculateTiming(Person person)
        {
            var current = DateTime.Today;
            int year = current.Month > person.Birthday.Month || current.Month == person.Birthday.Month && current.Day > person.Birthday.Day
                  ? current.Year + 1 : current.Year;
            person.Days = (int)(new DateTime(year, person.Birthday.Month, person.Birthday.Day) - current).TotalDays;

            person.Age = current.Year - person.Birthday.Year;
            if (person.Birthday.Date > current.AddYears(-person.Age)) person.Age--;
        }

        public static string GetDatabasePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
