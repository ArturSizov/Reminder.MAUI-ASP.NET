using Plugin.LocalNotification;
using Reminder.Contracts.Models;

namespace Reminder.Interfaces
{
    public interface IReminderNotificationServices
    {
        NotificationRequest Request { get; set; }
        void AddNotification(Person person);
    }
}