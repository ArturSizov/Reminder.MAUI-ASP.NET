using Reminder.Contracts.Models;
using System.Globalization;

namespace Reminder.MAUI.Services.Converters
{
    public class RowToBrushConverterAge : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var person = value as Person;

                if (person.Days <= 10) return Colors.Red;

                else if (person.Days <= 50) return Colors.SaddleBrown;

                else return Colors.Black;
            }

            else return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
