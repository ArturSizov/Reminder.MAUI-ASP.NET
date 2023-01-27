using System.Globalization;

namespace Reminder.Services.Converters
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            var current = DateTime.Today;

            var age = current.Year - date.Year;
            if (date.Date > current.AddYears(-age)) age--;
            return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
