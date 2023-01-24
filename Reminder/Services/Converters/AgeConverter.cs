using System.Globalization;

namespace Reminder.Services.Converters
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            var current = DateTime.Today;

            var age = (current.Year - date.Year) - 1;

            if (age < 0)
                return 0;
            else return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
