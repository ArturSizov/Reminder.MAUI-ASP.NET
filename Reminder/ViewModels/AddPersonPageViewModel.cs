using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
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
        private Person person = new();
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        public string Title => "Добавить";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public AddPersonPageViewModel(IRepository data)
        {
            this.data = data;

            IsEnabled = true;
        }

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });

        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        public ICommand SaveCommand => new DelegateCommand(async() =>
        {
            await data.InsertPerson(Person);
            await Shell.Current.GoToAsync("..");
        });

        public ICommand AddImageCommand => new DelegateCommand(async() =>
        {
            Person.Base64 = await Helper.AddImage();
        });
        #endregion
    }
}
