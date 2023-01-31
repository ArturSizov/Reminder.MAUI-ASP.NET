using Prism.Mvvm;

namespace Reminder.ViewModels.Popup
{
    public class PopupViewModel : BindableBase
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }
        public PopupViewModel(string text)
        {
            this.text = text;
        }
    }
}
