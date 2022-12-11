using Microsoft.Extensions.Logging;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Implementations;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.MAUI.ViewModels;
using Reminder.MAUI.Views;

namespace Reminder.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddSingleton<IPersonData, PersonData>();

            builder.Services.AddTransient<PersonsPage>();
            builder.Services.AddTransient<PersonsPageViewModel>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsPageViewModel>();
            builder.Services.AddTransient<AddPersonPage>();
            builder.Services.AddTransient<AddPersonPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}