using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.MAUI.Services;
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
            await Shell.Current.Navigation.PushAsync(new PersonsPage(new PersonsPageViewModel(data)));
        });

        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        public ICommand SaveCommand => new DelegateCommand(async() =>
        {
            await data.UpdatePerson(Person);
            await Shell.Current.Navigation.PushAsync(new PersonsPage(new PersonsPageViewModel(data)));

        });

        public ICommand AddImageCommand => new DelegateCommand(() =>
        {
            Helper.AddImage(Person);
        });

        public ICommand DeleteCommand => new DelegateCommand(async() =>
        {
            await data.DeletePerson(Person);
            await Shell.Current.Navigation.PushAsync(new PersonsPage(new PersonsPageViewModel(data)));
        });
        #endregion
    }
}
