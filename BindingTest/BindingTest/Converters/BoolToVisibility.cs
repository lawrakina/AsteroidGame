using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BindingTest.Converters
{

    //отображение только у соответствующий типов
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bool_value = System.Convert.ToBoolean(value);
            if (bool_value)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = System.Convert.ChangeType(value, typeof(Visibility));
            switch (visibility)
            {
                default: throw new NotSupportedException($"Значение {visibility} не поддерживается");
                case Visibility.Visible: return true;
                case Visibility.Hidden: return false;
            }
        }
    }
}
