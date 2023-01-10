using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using System.Collections.ObjectModel;

namespace Reminder.Data
{
    public class Repository : BindableBase, IRepository
    {
        #region Private property
        private readonly IPersonData data;
        private ObservableCollection<Person> persons;
        #endregion

        #region Public property
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion
        public Repository(IPersonData data )
        {
            this.data = data; 
            
            GetPersons();
        }

        #region Methods
        private async void GetPersons()
        {
            Persons = new ObservableCollection<Person>(await data.GetPersons());
        }
        #endregion
    }
}
