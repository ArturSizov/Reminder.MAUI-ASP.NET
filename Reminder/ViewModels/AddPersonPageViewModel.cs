using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Services;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class AddPersonPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private IRepository data;
        private IReminderNotificationServices notification;
        private Person person = new();
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        public string Title => "Добавить";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public AddPersonPageViewModel(IRepository data, IReminderNotificationServices notification)
        {
            this.data = data;
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
        /// Save Command
        /// </summary>
        public ICommand SaveCommand => new DelegateCommand<Person>(async(person) =>
        {
            if (!string.IsNullOrEmpty(person.Name))
            {
                await data.InsertPerson(person);
                await Shell.Current.GoToAsync("..");
#if ANDROID
                notification.AddNotification(person);
#endif
                if(person.Birthday.Day == DateTime.Now.Day)
                   await Shell.Current.DisplayAlert("Информация", "Дата рождения совпадает с сегодняшним днём.\nНапоминание сработает через год.", "Ok");
            }
            else await Shell.Current.DisplayAlert("Ошибка", "Поле \"Имя\" не может быть пустым", "Ok");

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
