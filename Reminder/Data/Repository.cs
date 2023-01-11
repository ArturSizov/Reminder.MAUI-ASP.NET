using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Services;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Reminder.Data
{
    public class Repository : BindableBase, IRepository
    {
        #region Private property
        private readonly IPersonData data;
        private ObservableCollection<Person> persons = new();
        #endregion

        #region Public property
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion
        public Repository(IPersonData data)
        {
            this.data = data;
            data.DatabasePath = GetDatabasePath("Reminder.sqlite.db");
            GetPersons();
        }

        #region Methods
        /// <summary>
        /// Load persons method
        /// </summary>
        private async void GetPersons()
        {
            Persons = new ObservableCollection<Person>(await data.GetPersons());
        }

        /// <summary>
        /// Getting a database row
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
        }
        #endregion
    }
}
