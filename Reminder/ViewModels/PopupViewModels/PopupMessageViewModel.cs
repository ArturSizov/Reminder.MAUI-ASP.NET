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

#if ANDROID
            var timer = new Timer(new TimerCallback(Close));
            timer.Change(8000, 0);
#endif
        }

        private void Close(object state)
        {
#if ANDROID

            MauiPopup.PopupAction.ClosePopup();
#endif
        }
    }
}
