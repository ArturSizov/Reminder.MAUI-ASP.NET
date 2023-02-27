namespace Reminder.Interfaces
{
    public interface ISettingsService
    {
        Task<T> GetSettings<T>(string key, T defaultValue);
        Task SaveSettings<T>(string key, T value);
        Task LoadData();

        int Time { get; set; }
        bool ShowNotifications { get; set; }
    }
}
