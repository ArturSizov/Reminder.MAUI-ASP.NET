#if ANDROID
using Plugin.LocalNotification;
#endif
using Reminder.Contracts.Models;
using Reminder.Interfaces;

namespace Reminder.Services
{
    public class ReminderNotificationServices : IReminderNotificationServices
    {
        #region Methods
        /// <summary>
        /// Method for adding notifications
        /// </summary>
        /// <param name="person"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task AddNotification(Person person, int time)
        {
#if ANDROID
            if (time > 23) time = 0;
 
            var date = new DateTime(DateTime.Now.Year, person.Birthday.Month, person.Birthday.Day, time, 0, 0);

            var notification = new NotificationRequest
            {
                NotificationId = person.Id,
                Title = "Напоминалка",
                Description = $"Поздравить: {person.Name} {person.LastName}",
                CategoryType = NotificationCategoryType.Reminder,  

                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = date,
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = person.Birthday.AddYears(1) - person.Birthday
                },
                Android = 
                {
                    IconSmallName =
                    {
                        ResourceName = "notification_message"
                    }
                }
            };
            notification.Android.ChannelId = "channel_01";
            await LocalNotificationCenter.Current.Show(notification);
#endif
        }
        #endregion

        /// <summary>
        /// Cancel a notification match with the Id
        /// </summary>
        /// <param name="person"></param>
        public void Cancel(Person person)
        {
#if ANDROID
            LocalNotificationCenter.Current.Cancel(person.Id);
#endif
        }

        /// <summary>
        /// Cancel all notifications
        /// </summary>
        public void CancelAll()
        {
#if ANDROID
            LocalNotificationCenter.Current.CancelAll();
#endif
        }

    }
}
