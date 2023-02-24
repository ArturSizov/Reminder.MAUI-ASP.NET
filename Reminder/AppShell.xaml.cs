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
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

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
    
        protected override bool OnBackButtonPressed()
        {
            var stack = Shell.Current.Navigation.NavigationStack;

            if(Shell.Current.FlyoutIsPresented) //Checks if it's open Flyout
            {
                Shell.Current.FlyoutIsPresented = false;

                return true;
            }               
            else
            {
                if (stack.Count > 1) //Checking if there are pages in the stack
                {
                    Shell.Current.Navigation.PopAsync();

                    return true;
                }
                else return false;
            }
        }

    }
}