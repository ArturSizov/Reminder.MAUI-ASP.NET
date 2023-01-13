﻿using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Private property
        private readonly IRepository data;
        private ObservableCollection<Person> persons;

        #endregion
        #region Public property
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }

        #endregion
        public PersonsPageViewModel(IRepository data)
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
        #region Command

        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async(person) =>
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
            {
                {nameof(DetailsPage), person }
            });
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
