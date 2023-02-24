using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Services;
using Reminder.ViewModels.PopupViewModels;
using Reminder.Views;
using Reminder.Views.ViewsPopup;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class SettingsPageViewModel : BindableBase
    {
        #region Private property
        private int time;
        private bool showNotifications;
        private readonly ISettingsService settings;
        private readonly IReminderNotificationServices services;
        private readonly IRepository repository;
        #endregion

        #region Pubcic property
        public string Title => "Настройки";
        public int Time { get => time; set => SetProperty(ref time, value); }
        public bool ShowNotifications { get => showNotifications; set => SetProperty(ref showNotifications, value); }

        #endregion

        public SettingsPageViewModel(ISettingsService settings, IReminderNotificationServices services, IRepository repository)
        {
            this.settings = settings;
            this.services = services;
            this.repository = repository;
            Time = settings.Time;
            ShowNotifications = settings.ShowNotifications;
        }

        #region Commands
        public ICommand SaveCommand => new DelegateCommand(async() =>
        {
            settings.Time = Time;
            settings.ShowNotifications = ShowNotifications;
            await Shell.Current.Navigation.PopAsync();
            IsEnabledNotifications();

        });
        #endregion

        #region Methods
        private void IsEnabledNotifications()
        {
            if (ShowNotifications)
            {
                foreach (var item in repository.Persons)
                {
                    services.AddNotification(item, time);
                }
#if ANDROID
                MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel($"Напоминания включены.\nВремя напоминаний {time} ч.")));
#endif
            }
            else
            {
                services.CancelAll();
#if ANDROID
                MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel("Уведомления отключены")));
#endif
            }
        }
#endregion
    }
}
