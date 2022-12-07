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
        private readonly IPersonData personData;
        #endregion

        #region Public property  
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        public string DetailInformation { get; set; }
        #endregion

        public PersonsPageViewModel(/*IPersonData personData*/)
        {
            //this.personData.GetPersons();

           Persons = new ObservableCollection<Person> 
           { 
               new Person
               {
                   Name = "Artur",
                   Age= 30,
                   Base64 = "https://klike.net/uploads/posts/2022-07/1657089857_1.jpg",
                   Birthday= DateTime.Now,
                   Days = 55,
                   LastName = "Sizov",
                   MiddleName = "Gennadevich"
               },
               new Person
               {
                   Name = "Amir",
                   Age= 30,
                   Base64 = "https://kartinkof.club/uploads/posts/2022-03/1648632825_1-kartinkof-club-p-smeshnie-kartinki-multiki-1.jpg",
                   Birthday= DateTime.Now,
                   Days = 55,
                   LastName = "Sizov",
                   MiddleName = "Gennadevich"
               },
                new Person
               {
                   Name = "Adel",
                   Age= 30,
                   Base64 = "https://i.pinimg.com/550x/80/5c/7a/805c7ad0484dfc4e1dffba153e1e5e8e.jpg",
                   Birthday= DateTime.Now,
                   Days = 55,
                   LastName = "Sizov",
                   MiddleName = "Gennadevich"
               }
           };
            this.personData = personData;

            DetailInformation = "Осталось 150 дней до дня рождения";
        }

        #region Command
        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async(person) =>
        {
            await Shell.Current.Navigation.PushAsync(new DetailsPage(new DetailsPageViewModel
            {
                Person = person
            }));
        });
        #endregion

    }
}
