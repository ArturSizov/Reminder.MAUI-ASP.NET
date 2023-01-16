using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        }
        #region Methods
        /// <summary>
        /// Get persons method
        /// </summary>
        public async Task<List<Person>> GetPersons()
        {
            return new ObservableCollection<Person>(await data.GetPersons()).ToList();
        }

        /// <summary>
        /// Insert Person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task InsertPerson(Person person)
        {
            Persons.Add(person);
            await data.InsertPerson(person);
        }
        /// <summary>
        /// Update Person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePerson(Person person)
        {
            var item = Persons.FirstOrDefault(i => i.Id == person.Id);
            if (item != null)
            {
                item.Name = person.Name;
                item.LastName = person.LastName;
                item.MiddleName = person.MiddleName;
                item.Base64 = person.Base64;
                item.Position = person.Position;
                item.Birthday = person.Birthday;
            }
            await data.UpdatePerson(person);  
        }

        /// <summary>
        /// Delete Person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task DeletePerson(Person person)
        {
            var persons = new ObservableCollection<Person>(Persons);
            Persons.Clear();
            foreach (var item in persons)
            {
                if (item.Id != person.Id)
                    Persons.Add(item);
            }
            await data.DeletePerson(person);
        }

        /// <summary>
        /// Getting a database row
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string GetDatabasePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }

       #endregion
    }
}
