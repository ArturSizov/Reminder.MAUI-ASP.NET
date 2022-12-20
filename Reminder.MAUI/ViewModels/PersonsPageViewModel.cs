using Prism.Mvvm;
using Prism.Commands;
using Reminder.Contracts.Models;
using System.Collections.ObjectModel;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using System.Windows.Input;
using Reminder.MAUI.Views;
using Reminder.MAUI.Services;

namespace Reminder.MAUI.ViewModels
{
    public class PersonsPageViewModel : BindableBase 
    {
        #region Privet property
        private ObservableCollection<Person> persons = new();
        private readonly IPersonData data;
        #endregion

        #region Public property  
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion

        public PersonsPageViewModel(IPersonData data)
        {
            this.data = data;

            GetPersons();
        }

        #region Methods
        public async void GetPersons()
        {
            var persons = new ObservableCollection<Person>(await data.GetPersons());

            foreach (var item in persons)
            {
                Helper.CalculateTiming(item);
                Persons.Add(item);
            }
        }
        #endregion
        #region Command
        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async(person) =>
        {
            await Shell.Current.Navigation.PushAsync(new DetailsPage(new DetailsPageViewModel(data)
            {
                Person = person
            }));
        });

        public ICommand GoToAddPersonCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.Navigation.PushAsync(new AddPersonPage(new AddPersonPageViewModel(data)));
        });

        public ICommand GoToReportsCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PushAsync(new ReportsPage(new RerportsPageViewModel()));

        });
        #endregion

    }
}
