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
                   Base64 = "image",
                   Birthday= DateTime.Now,
                   Days = 55,
                   LastName = "Sizov",
                   MiddleName = "Gennadevich"
               },
               new Person
               {
                   Name = "Amir",
                   Age= 30,
                   Base64 = "image",
                   Birthday= DateTime.Now,
                   Days = 55,
                   LastName = "Sizov",
                   MiddleName = "Gennadevich"
               }
           };
            this.personData = personData;
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
