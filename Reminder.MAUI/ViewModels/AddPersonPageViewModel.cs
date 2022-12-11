using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class AddPersonPageViewModel : BindableBase
    {
        #region Public property
        public string Title => "Добавить";
        #endregion

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopToRootAsync();
        });

        #endregion
    }
}
