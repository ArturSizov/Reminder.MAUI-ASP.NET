using Prism.Mvvm;
using Reminder.Interfaces;

namespace Reminder.Services
{
    public class SettingsService : BindableBase, ISettingsService
    {
        #region Private property
        private int time;
        private bool showNotifications;
        #endregion

        #region Pubcic property
        public int Time { get => time; set => SetProperty(ref time, value); }
        public bool ShowNotifications { get => showNotifications; set => SetProperty(ref showNotifications, value); }
        #endregion

        #region Metshods
        /// <summary>
        /// Get settings App
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> GetSettings<T>(string key, T defaultValue)
        {
            var result = Preferences.Default.Get<T>(key, defaultValue);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Set settings App
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task SaveSettings<T>(string key, T value)
        {
            Preferences.Default.Set(key, value);
            return Task.CompletedTask;
        }
        #endregion

    }
}
