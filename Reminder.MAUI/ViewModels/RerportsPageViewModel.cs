using Prism.Commands;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class RerportsPageViewModel
    {
        #region Public property
        public string Title => "Отчёт";
        #endregion

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopToRootAsync();
        });
        #endregion
    }
}
