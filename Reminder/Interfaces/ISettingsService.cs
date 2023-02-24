namespace Reminder.Interfaces
{
    public interface ISettingsService
    {
        Task<T> GetSettings<T>(string key, T defaultValue);
        Task SaveSettings<T>(string key, T value);

        int Time { get; set; }
        public bool ShowNotifications { get; set; }
 
    }
}
