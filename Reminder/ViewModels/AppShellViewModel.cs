using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class AppShellViewModel
    {
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.DisplayAlert("Message", "Messsa...", "Ok");
        });
    }
}
