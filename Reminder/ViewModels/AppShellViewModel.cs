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
            await Shell.Current.GoToAsync(nameof(AddPersonPage));

            Shell.Current.FlyoutIsPresented = false;
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
            await Shell.Current.GoToAsync(nameof(SettingsPage));

            Shell.Current.FlyoutIsPresented = false;
        });
        #endregion
    }
}
