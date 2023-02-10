using Plugin.LocalNotification;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.ViewModels.PopupViewModels;
using Reminder.Views.ViewsPopup;

namespace Reminder.Services
{
    public class ReminderNotificationServices : IReminderNotificationServices
    {
//#if ANDROID
        private INotificationService notificationService;
//#endif
        public ReminderNotificationServices(INotificationService notificationService)
        {
//#if ANDROID
            this.notificationService = notificationService;
            
//#endif
        }
        public async Task AddNotification(Person person, int time)
        {
            //#if ANDROID
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
                    NotifyRepeatInterval = TimeSpan.FromMinutes(2),
                    //NotifyRepeatInterval = person.Birthday.AddYears(1) - person.Birthday
                },
                Android = 
                {
                    IconSmallName =
                    {
                        ResourceName = "notification_bell"
                    }
                }
            };
            notification.Android.ChannelId = "channel_01";
            await notificationService.Show(notification);
//#endif
        }
    }
}
