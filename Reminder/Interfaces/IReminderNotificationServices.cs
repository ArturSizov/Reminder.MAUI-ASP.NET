using Reminder.Contracts.Models;

namespace Reminder.Interfaces
{
    public interface IReminderNotificationServices
    {
        void AddNotification(Person person);
    }
}