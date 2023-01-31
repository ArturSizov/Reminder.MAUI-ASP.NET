using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Reminder.Contracts.Models;
using Reminder.Interfaces;

namespace Reminder.Services
{
    public class ReminderNotificationServices : IReminderNotificationServices
    {
#if ANDROID
        public NotificationRequest Request { get; set; }
#endif
        public void AddNotification(Person person)
        {
#if ANDROID
            Request = new NotificationRequest
            {
                NotificationId = person.Id,
                Title = "Напоминалка",
                Description = $"Поздравить: {person.Name} {person.LastName}",
                CategoryType = NotificationCategoryType.Reminder,
                Schedule = new NotificationRequestSchedule

                {
                    NotifyTime = DateTime.Now.AddSeconds(GetDaysAge(person.Birthday)),
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = person.Birthday.AddYears(1) - person.Birthday
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
#endif
        }

        private int GetDaysAge(DateTime date)
        {
            var current = DateTime.Today;

            int year = current.Month > date.Month || current.Month == date.Month && current.Day > date.Day ? current.Year + 1 : current.Year;

            var days = (int)(new DateTime(year, date.Month, date.Day) - current).TotalDays;

            if(days == 0)
            {
                return (int)(current.AddYears(1) - current).TotalDays;
            }
            else return days;
        }
    }
}
