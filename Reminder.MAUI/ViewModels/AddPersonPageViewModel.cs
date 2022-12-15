using Microsoft.Maui.Graphics;
using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.MAUI.Services;
using Reminder.MAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class AddPersonPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private IPersonData data;
        private ObservableCollection<Person> persons = new();
        #endregion

        #region Public property
        public Person Person { get; set; }
        public string Title => "Добавить";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion

        public AddPersonPageViewModel(IPersonData data)
        {
            this.data = data;

            Person = new Person();

            IsEnabled = true;
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
            await data.InsertPerson(Person);
            await Shell.Current.Navigation.PushAsync(new PersonsPage(new PersonsPageViewModel(data)));
        });

        public ICommand AddImageCommand => new DelegateCommand(() =>
        {
           Helper.AddImage(Person);
        });
        #endregion
    }
}
