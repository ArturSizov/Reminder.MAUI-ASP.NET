using Prism.Mvvm;
using Reminder.Interfaces;

namespace Reminder.Services
{
    public class SettingsService : BindableBase, ISettingsService
    {
        #region Private property
        private int time;
        private bool showNotifications = true;
        #endregion

        #region Pubcic property
        public int Time { get => time; set => SetProperty(ref time, value); }
        public bool ShowNotifications { get => showNotifications; set => SetProperty(ref showNotifications, value); }
        #endregion

    }
}
