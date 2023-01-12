using Prism.Commands;
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

        public bool IsVisibleEmptyView { get; set; }
        #endregion
        public PersonsPageViewModel(IRepository data)
        {
            this.data = data;
            Persons = this.data.Persons;
        }
        #region Methods
       
        #endregion
        #region Command

        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async (person) =>
        {
            //await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
            //{
            //    {nameof(DetailsPage), person }
            //});
        });

        public ICommand GoToAddPersonCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("...");
        });

        public ICommand GoToReportsCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("...");
        });

        #endregion
    }
}
