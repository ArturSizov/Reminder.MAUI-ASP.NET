using System.Globalization;

namespace Reminder.MAUI.Services.Converters
{
    public class RowToBrushConverterAgeDetailsPage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((int)value <= 10) return Colors.Red;

                else if ((int)value <= 50) return Colors.SaddleBrown;

                else return Colors.White;
            }

            else return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
