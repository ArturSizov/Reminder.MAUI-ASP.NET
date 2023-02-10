using Reminder.Interfaces;

namespace Reminder.Services
{
    public class SettingsService
    {
        public int Time { get; set; }
        public SettingsService()
        {
            Time = 10;
        }
    }
}
