using System.Globalization;

namespace Reminder.Services.Converters
{
    public class RowToBrushDaysBirthdayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "")
                return null;

            var date = int.Parse((string)value);

            if (date <= 10) return Colors.Red;

            else if (date <= 50) return Colors.SaddleBrown;

            if ((string)parameter == "PersonsPage") return Colors.Black;

            else return Colors.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
