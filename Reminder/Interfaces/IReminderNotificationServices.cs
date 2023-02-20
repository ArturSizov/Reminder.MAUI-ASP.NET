using Reminder.Contracts.Models;

namespace Reminder.Interfaces
{
    public interface IReminderNotificationServices
    {
        Task AddNotification(Person person, int time);
        void Cancel(Person person);
    }
}