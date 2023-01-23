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

namespace Reminder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
//#if ANDROID
                .UseLocalNotification(config =>
                {
                    config.AddCategory(new NotificationCategory(NotificationCategoryType.Status)
                    {
                        ActionList = new HashSet<NotificationAction>(new List<NotificationAction>()
                            {
                               new NotificationAction(100)
                                    {
                                            Title = "Открыть",
                                            Android =
                                            {
                                                LaunchAppWhenTapped = true,
                                                IconName =
                                                {
                                                   ResourceName = "i2"
                                                }
                                            }
                                    },
                               new NotificationAction(101)
                                    {
                                            Title = "Закрыть",
                                            Android =
                                            {
                                                LaunchAppWhenTapped = false,
                                                IconName =
                                                {
                                                   ResourceName = "i3"
                                                }
                                            }
                                    }
                            })
                    });
                    config.AddAndroid(android =>
                    {
                        android.AddChannel(new NotificationChannelRequest
                        {
                            Id = $"my_channel_01",
                            Name = "General",
                            Description = "General",
                        });
                        android.AddChannel(new NotificationChannelRequest
                        {
                            Id = $"my_channel_02",
                            Name = "Special",
                            Description = "Special",
                        });
                    });
                })
//#endif
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
#if ANDROID
            builder.Services.AddSingleton<IReminderNotificationServices, ReminderNotificationServices>();
#endif
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