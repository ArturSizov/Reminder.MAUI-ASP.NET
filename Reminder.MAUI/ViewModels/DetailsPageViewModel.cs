using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.MAUI.Views;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class DetailsPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private readonly IPersonData data;
        #endregion

        #region Public property
        public Person Person { get; set; }
        public string Title => $"{Person.LastName} {Person.Name} {Person.MiddleName}";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        #endregion

        public DetailsPageViewModel(IPersonData data)
        {
            IsEnabled = false;
            this.data = data;
        }

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopToRootAsync();
        });

        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        public ICommand SaveCommand => new DelegateCommand(() =>
        {
            IsEnabled = false;
        });

        public ICommand AddImageCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.Navigation.PushAsync(new AddPersonPage(new AddPersonPageViewModel(data)));

        });

        public ICommand DeleteCommand => new DelegateCommand<Person>(async(person) =>
        {
            await data.DeletePerson(person.Id);
            await Shell.Current.Navigation.PopToRootAsync();
        });
        #endregion
    }
}
