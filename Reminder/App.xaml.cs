using Microsoft.Maui.Platform;
using Reminder.Handlers;

namespace Reminder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif WINDOWS
                    handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Light;
#endif
                }
            });

    Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(SearchEntry), (handler, view) =>
            {
                if (view is SearchEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
                    handler.PlatformView.TextCursorDrawable.SetTint(Colors.Gray.ToPlatform());
#elif WINDOWS
                    handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Light;
#endif
                }
            });
            MainPage = new AppShell();
        }
    }
}