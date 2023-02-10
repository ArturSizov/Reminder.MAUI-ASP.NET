using Plugin.LocalNotification;
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
    [QueryProperty("Person", nameof(DetailsPage))]
    public partial class DetailsPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private Person person;
        private readonly IRepository data;
        private readonly ISettingsService settings;
        private readonly IReminderNotificationServices notification;
#if ANDROID
        private INotificationService notificationServices;
#endif
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        public string Title => $"{person.Name} {person.LastName}";
        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public DetailsPageViewModel(IRepository data, INotificationService notificationServices,
            IReminderNotificationServices notification, ISettingsService settings)
        {
            IsEnabled = false;
            this.data = data;
            this.settings = settings;
#if ANDROID
            this.notification = notification;
            this.notificationServices = notificationServices;
#endif
        }

        #region Commands
        /// <summary>
        /// Back button command
        /// </summary>
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });

        /// <summary>
        /// Is enabled command
        /// </summary>
        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        /// <summary>
        /// Save command
        /// </summary>
        public ICommand SaveCommand => new DelegateCommand<Person>(async(person) =>
        {
            if (!string.IsNullOrEmpty(person.Name))
            {
                await data.UpdatePerson(person);

                await Shell.Current.GoToAsync("..");

                await Helper.Announcement(person, settings.Time);
#if ANDROID
                notificationServices.Cancel(person.Id);
#endif
                await notification.AddNotification(person, settings.Time);
            }
            else await MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel("Поле \"Имя\" не может быть пустым")));

        });

        /// <summary>
        /// Add image command
        /// </summary>
        public ICommand AddImageCommand => new DelegateCommand(async () =>
        {
            Person.Base64 = await Helper.AddImage();
        });

        /// <summary>
        /// Delete command
        /// </summary>
        public ICommand DeleteCommand => new DelegateCommand<Person>(async (person) =>
        {
            if (await Shell.Current.DisplayAlert("Внимание", $"Вы уверены, что хотите удалить всю информацию для: {person.Name}?", "Да", "Нет"))
            {
                await data.DeletePerson(person);
                await Shell.Current.GoToAsync("..");
#if ANDROID
                notificationServices.Cancel(person.Id);
#endif
            }
            else return;
        });
        #endregion
    }
}
