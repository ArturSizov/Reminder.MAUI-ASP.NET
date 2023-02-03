using CommunityToolkit.Maui.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace Reminder.ViewModels.PopupViewModels
{
    public class PopupMessageViewModel : BindableBase
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }
        public PopupMessageViewModel(string text)
        {
            this.text = text;
        }

        public ICommand Close => new DelegateCommand<Popup>((popup) =>
        {
            popup.Close();
        });
    }
}
