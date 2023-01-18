using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Implementations;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Data;
using Reminder.Interfaces;
using Reminder.ViewModels;
using Reminder.Views;

namespace Reminder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
#if ANDROID
                .UseLocalNotification(config =>
                {
                    config.AddCategory(new NotificationCategory(NotificationCategoryType.Status)
                    {
                        ActionList = new HashSet<NotificationAction>(new List<NotificationAction>()
                          {
                             new NotificationAction(100)
                             {
                                Title = "Hello",
                                Android =
                                {
                                  LaunchAppWhenTapped = true,
                                  IconName =
                                  {
                                    ResourceName = "i2"
                                  }
                                }
                              }
                         })
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

            // register Pages
            builder.Services.AddSingleton<PersonsPage>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<AddPersonPage>();

            // register ViewModels
            builder.Services.AddSingleton<PersonsPageViewModel>();
            builder.Services.AddTransient<DetailsPageViewModel>();
            builder.Services.AddTransient<AddPersonPageViewModel>();

            return builder.Build();
        }
    }
}