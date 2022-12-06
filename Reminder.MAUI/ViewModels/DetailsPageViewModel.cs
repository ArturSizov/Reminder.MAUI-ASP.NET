using Prism.Mvvm;
using Reminder.Contracts.Models;

namespace Reminder.MAUI.ViewModels
{
    public class DetailsPageViewModel : BindableBase
    {
        #region Private ptoperty
        private Person person;
        #endregion

        #region Public property
        public Person Person { get => person; set => SetProperty(ref person, value); }
        #endregion

        public DetailsPageViewModel()
        {
          
        }
    }
}
