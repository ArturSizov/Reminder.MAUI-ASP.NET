using System.Globalization;

namespace Reminder.Services.Converters
{
    public class SetTextMessageConverter : IValueConverter
    {
        int[] age = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 95, 100 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            var current = DateTime.Today;

            var agePerson = current.Year - date.Year;

            string text = null;

            foreach (var a in age)
            {
                if (agePerson + 1 == a)
                {
                    text = "Осталось дней до Юбилея: ";
                    break;
                }
                else text = "Осталось дней до дня рождения: ";
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
