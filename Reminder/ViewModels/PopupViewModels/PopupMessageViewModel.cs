using Prism.Mvvm;

namespace Reminder.ViewModels.PopupViewModels
{
    public class PopupMessageViewModel : BindableBase
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }

        public PopupMessageViewModel(string text)
        {
            this.text = text;
            Timer timer = new Timer(new TimerCallback(Close));
            timer.Change(10000, 0);
        }

        private void Close(object state)
        {
            MauiPopup.PopupAction.ClosePopup();
        }
    }
}
