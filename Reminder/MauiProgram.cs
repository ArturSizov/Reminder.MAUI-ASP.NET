using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Implementations;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Data;
using Reminder.Interfaces;
using Reminder.ViewModels;
using Reminder.Views;
using Reminder.Services;
using Plugin.LocalNotification.AndroidOption;
using CommunityToolkit.Maui;

namespace Reminder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
#if ANDROID
                .UseLocalNotification(config =>
                {
                    config.AddAndroid(android =>
                    {
                        android.AddChannel(new NotificationChannelRequest
                        {
                            Id = $"channel_01",
                            Name = "General",
                            Description = "General"
                        });
                        android.AddChannel(new NotificationChannelRequest
                        {
                            Id = $"channel_02",
                            Name = "Special",
                            Description = "Special"
                        });
                    });
                })
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            //register Services
            builder.Services.AddSingleton<IDataProvider, DataProvider>();
            builder.Services.AddSingleton<IPersonData, PersonData>();
            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddSingleton<IReminderNotificationServices, ReminderNotificationServices>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();

            // register Pages
            builder.Services.AddSingleton<PersonsPage>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<AddPersonPage>();
            builder.Services.AddTransient<SettingsPage>();

            // register ViewModels
            builder.Services.AddSingleton<PersonsPageViewModel>();
            builder.Services.AddTransient<DetailsPageViewModel>();
            builder.Services.AddTransient<AddPersonPageViewModel>();
            builder.Services.AddTransient<SettingsPageViewModel>();
            return builder.Build();
        }
    }
}