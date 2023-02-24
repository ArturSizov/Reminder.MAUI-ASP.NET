namespace Reminder.Interfaces
{
    public interface ISettingsService
    {
        int Time { get; set; }
        public bool ShowNotifications { get; set; }
 
    }
}
