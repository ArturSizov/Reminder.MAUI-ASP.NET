using Prism.Mvvm;
using Prism.Commands;
using Reminder.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.MAUI.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Privet property
        private ObservableCollection<Person> persons;
        #endregion

        #region Public property  
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion

        public PersonsPageViewModel()
        {
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
               }
           };
        }

    }
}
