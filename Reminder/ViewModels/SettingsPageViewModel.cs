using Prism.Mvvm;
using Reminder.Interfaces;

namespace Reminder.ViewModels
{
    public class SettingsPageViewModel : BindableBase, ISettingsService
    {
        #region Private property
        private int time;
        #endregion

        #region Pubcic property
        public int Time { get => time; set => SetProperty(ref time, value); }

        #endregion

        public SettingsPageViewModel()
        {
            Time = 16;
        }
    }
}
