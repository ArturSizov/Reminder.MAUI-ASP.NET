using System.Globalization;

namespace Reminder.Services.Converters
{
    public class DaysBirthdayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            var current = DateTime.Today;
            int year = current.Month > date.Month || current.Month == date.Month && current.Day > date.Day
            ? current.Year + 1 : current.Year;
            return (int)(new DateTime(year, date.Month, date.Day) - current).TotalDays;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
