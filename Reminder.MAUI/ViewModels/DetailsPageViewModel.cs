﻿using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class DetailsPageViewModel : BindableBase
    {
        #region Private ptoperty

        #endregion

        #region Public property
        public Person Person { get; set; }
        public string Title => $"{Person.LastName} {Person.Name} {Person.MiddleName}";
        #endregion

        public DetailsPageViewModel()
        {
        }

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopToRootAsync();
        });
        #endregion
    }
}
