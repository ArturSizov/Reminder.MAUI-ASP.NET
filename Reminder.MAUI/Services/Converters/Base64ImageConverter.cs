﻿using System.Globalization;

namespace Reminder.MAUI.Services.Converters
{
    public class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return "noavatar.png";
            var base64 = (string)value;
            return ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(base64)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
