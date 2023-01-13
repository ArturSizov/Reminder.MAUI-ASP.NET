using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Services;
using Reminder.Views;
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
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        public string Title => $"{person.Name} {person.LastName}";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public DetailsPageViewModel(IRepository data)
        {
            IsEnabled = false;
            this.data = data;
        }

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.GoToAsync("..");
        });

        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        public ICommand SaveCommand => new DelegateCommand(async () =>
        {
            //await data.UpdatePerson(person);
            await Shell.Current.GoToAsync("..");
        });

        public ICommand AddImageCommand => new DelegateCommand(async () =>
        {
            person.Base64 = await Helper.AddImage();
        });

        public ICommand DeleteCommand => new DelegateCommand(async () =>
        {
            //await data.DeletePerson(person);
            await Shell.Current.GoToAsync("..");
        });
        #endregion
    }
}
