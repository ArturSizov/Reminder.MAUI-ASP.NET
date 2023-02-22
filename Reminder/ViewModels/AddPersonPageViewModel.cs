using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Services;
using System.Windows.Input;
using Reminder.Views.ViewsPopup;
using Reminder.ViewModels.PopupViewModels;
using Reminder.Views;

namespace Reminder.ViewModels
{
    public class AddPersonPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private IRepository data;
        private readonly ISettingsService settings;
        private IReminderNotificationServices notification;
        private Person person = new();
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        public string Title => "Добавить";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public AddPersonPageViewModel(IRepository data, IReminderNotificationServices notification, ISettingsService settings)
        {
            this.data = data;
            this.settings = settings;
            this.notification = notification;

            IsEnabled = true;
        }
        #region Methods

        #endregion

        #region Commands
        /// <summary>
        /// Back button command
        /// </summary>
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopAsync();
        });

        /// <summary>
        /// Is enabled command
        /// </summary>
        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        /// <summary>
        /// Save Command
        /// </summary>
        public ICommand SaveCommand => new DelegateCommand<Person>(async(person) =>
        {
            if (!string.IsNullOrEmpty(person.Name))
            {
                await data.InsertPerson(person);

                await Shell.Current.Navigation.PopAsync();

                await notification.AddNotification(person, settings.Time);

                await Helper.Announcement(person, settings.Time);
            }
#if ANDROID

            else await MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel("Поле \"Имя\" не может быть пустым")));
#elif WINDOWS
            else await Shell.Current.DisplayAlert("Информация", "Поле \"Имя\" не может быть пустым", "Ok");
#endif
        });

        /// <summary>
        /// Add image command
        /// </summary>
        public ICommand AddImageCommand => new DelegateCommand(async() =>
        {
            Person.Base64 = await Helper.AddImage();
        });
#endregion
    }
}
