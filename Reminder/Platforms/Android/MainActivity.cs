using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotification;

namespace Reminder
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, NoHistory = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation 
        | ConfigChanges.UiMode | ConfigChanges.ScreenLayout
        | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var data = Intent.GetStringExtra(LocalNotificationCenter.ReturnRequest);
            var mainIntent = new Intent(MauiApplication.Context, typeof(MainActivity));

            mainIntent.SetFlags(ActivityFlags.SingleTop);
            if (!string.IsNullOrWhiteSpace(data))
            {
                mainIntent.PutExtra(data, false);
            }

            StartActivity(mainIntent);
        }
    }
}