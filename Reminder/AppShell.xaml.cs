using Reminder.ViewModels;
using Reminder.Views;

namespace Reminder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPersonPage), typeof(AddPersonPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));

            BindingContext = new AppShellViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
#if ANDROID
            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#FFC107"));

            //Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.AddFlags(Android.Views.WindowManagerFlags.LayoutAttachedInDecor);
#endif
        }
    }
}