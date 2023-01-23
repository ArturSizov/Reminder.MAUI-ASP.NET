using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Reminder.Contracts.Models;
using Reminder.Interfaces;

namespace Reminder.Services
{
    public class ReminderNotificationServices : IReminderNotificationServices
    {
        public NotificationRequest Request { get; set; }

        public void AddNotification(Person person)
        {
            Request = new NotificationRequest
            {
                NotificationId = person.Id,
                Title = "Напоминалка",
                Description = $"Поздравить: {person.Name} {person.LastName}",
                CategoryType = NotificationCategoryType.Status,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(GetDaysAge(person.Birthday)),
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = TimeSpan.FromSeconds(GetDaysAge(person.Birthday))
                },
                Android = new AndroidOptions
                {
                    IconSmallName =
                    {
                       ResourceName = "notification"
                    }
                }
            };

            LocalNotificationCenter.Current.Show(Request);
        }

        /// <summary>
        /// Return days to birthday
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private int GetDaysAge(DateTime date)
        {
            var current = DateTime.Today;
            int year = current.Month > date.Month || current.Month == date.Month && current.Day > date.Day
            ? current.Year + 1 : current.Year;
            return (int)(new DateTime(year, date.Month, date.Day) - current).TotalDays;
        }
    }
}
