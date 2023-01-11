using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Private property
        private readonly IRepository data;
        private ObservableCollection<Person> persons = new();

        #endregion
        #region Public property
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion
        public PersonsPageViewModel(IRepository data)
        {
            this.data = data;
            Persons = this.data.Persons;
        }
    }
}
