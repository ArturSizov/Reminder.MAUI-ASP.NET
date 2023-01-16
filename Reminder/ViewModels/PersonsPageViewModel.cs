﻿using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Private property
        private readonly IRepository data;
        private ObservableCollection<Person> persons;
        private bool isBusy;

        #endregion
        #region Public property
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); } //ActivityIndicator is busy

        #endregion
        public PersonsPageViewModel(IRepository data)
        {
            this.data = data;
            GetPersons();
        }
        #region Methods

        /// <summary>
        /// Get Persons method
        /// </summary>
        private async void GetPersons()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;
                Persons = data.Persons = new ObservableCollection<Person>(await data.GetPersons());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
        #region Command

        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async(person) =>
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
            {
                {nameof(DetailsPage), person
                    //new Person
                    //{
                    //     Name = person.Name, Id = person.Id, Base64 = person.Base64,
                    //     Birthday= person.Birthday, LastName = person.LastName, MiddleName = person.MiddleName, Position = person.Position
                    //}
                }});
        });

        public ICommand GoToAddPersonCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        });

        public ICommand GoToReportsCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("...");
        });

        private static string GetDatabasePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        #endregion
    }
}
