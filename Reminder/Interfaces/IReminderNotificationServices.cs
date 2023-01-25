using Plugin.LocalNotification;
using Reminder.Contracts.Models;

namespace Reminder.Interfaces
{
    public interface IReminderNotificationServices
    {
#if ANDROID
        NotificationRequest Request { get; set; }
        void AddNotification(Person person);
#endif
    }
}