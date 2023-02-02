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
            var date = new DateTime(person.Birthday.Year, person.Birthday.Month, person.Birthday.Day, 0, 01, 0);

            Request = new NotificationRequest
            {
                NotificationId = person.Id,
                Title = "Напоминалка",
                Description = $"Поздравить: {person.Name} {person.LastName}",
                CategoryType = NotificationCategoryType.Reminder,

                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddDays(GetDaysAge(date)),
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                    //NotifyRepeatInterval = person.Birthday.AddYears(1) - person.Birthday
                },
                Android = new AndroidOptions
                {
                    IconSmallName =
                    {
                        ResourceName = "notification_bell"
                    }
                }
            };

            LocalNotificationCenter.Current.Show(Request);
#endif
        }

        private int GetDaysAge(DateTime birthday)
        {
            var today = DateTime.Today;

            var date = birthday.AddYears(today.Year - birthday.Year);

            if (date < today)
                date = date.AddYears(1);

            var days = (date - today).Days;

            if (days == 0)
            {
                return (date.AddYears(1) - today).Days;
            }
            else return days;
        }
    }
}
