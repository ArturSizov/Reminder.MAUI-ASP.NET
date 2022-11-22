using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration["DbConnection"];

            //var s = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            //services.AddDbContext<ScreenshotsDbContext>(options =>
            //{
            //    options.UseSqlite(connectionString);
            //});
            //services.AddScoped<IScreenshoterDbContext>(provider => provider.GetService<ScreenshotsDbContext>());
            return services;
        }
    }
}
