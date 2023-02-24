using Prism.Commands;
using Reminder.Views;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class AppShellViewModel
    {

        #region Commands
        /// <summary>
        /// Add Person command
        /// </summary>
        public ICommand GoToAddPersonCommand => new DelegateCommand(async() =>
        {
            Shell.Current.FlyoutIsPresented = false;

            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        });

        /// <summary>
        /// Show message command
        /// </summary>
        public ICommand ShowMessageCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.DisplayAlert("О программе", "Программа для напоминаний о днях рождений", "Ok");
        });

        /// <summary>
        /// Show message command
        /// </summary>
        public ICommand GoToSettingCommand => new DelegateCommand(async () =>
        {
            Shell.Current.FlyoutIsPresented = false;

            await Shell.Current.GoToAsync(nameof(SettingsPage));
        });
        #endregion
    }
}
