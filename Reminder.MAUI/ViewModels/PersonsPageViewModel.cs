using Prism.Mvvm;
using Prism.Commands;
using Reminder.Contracts.Models;
using System.Collections.ObjectModel;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using System.Windows.Input;
using Reminder.MAUI.Views;

namespace Reminder.MAUI.ViewModels
{
    public class PersonsPageViewModel : BindableBase 
    {
        #region Privet property
        private ObservableCollection<Person> persons;
        private readonly IPersonData data;
        #endregion

        #region Public property  
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        public string DetailInformation { get; set; }
        #endregion

        public PersonsPageViewModel(IPersonData data)
        {
            this.data = data;

            GetPersons();

            DetailInformation = "Осталось 150 дней до дня рождения";
        }

        #region Methods
        public async void GetPersons()
        {
            Persons = new ObservableCollection<Person>(await data.GetPersons());
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
