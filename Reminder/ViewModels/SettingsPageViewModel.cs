using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Views;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class SettingsPageViewModel : BindableBase
    {
        #region Private property
        private int time;
        private bool showNotifications;
        private readonly ISettingsService settings;
        #endregion

        #region Pubcic property
        public string Title => "Настройки";
        public int Time { get => time; set => SetProperty(ref time, value); }
        public bool ShowNotifications { get => showNotifications; set => SetProperty(ref showNotifications, value); }

        #endregion

        public SettingsPageViewModel(ISettingsService settings)
        {
            this.settings = settings;
            Time = settings.Time;
            ShowNotifications = settings.ShowNotifications;
        }

        #region Commands
        public ICommand SaveCommand => new DelegateCommand(async () =>
        {
            settings.Time = Time;
            settings.ShowNotifications = ShowNotifications;
            await Shell.Current.Navigation.PopAsync();
        });
        #endregion
    }
}
