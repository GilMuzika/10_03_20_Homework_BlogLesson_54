using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _10_03_20_Homework_BlogLesson_54
{
    public class BooleanToStringConverter : IValueConverter
    {
        private string _raw;

        public BooleanToStringConverter(string raw)
        {
            _raw = raw;
        }
        public BooleanToStringConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueBool = (bool)value;
            return valueBool ? _raw : $"Not {_raw.ToLower()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            if (value.Equals(_raw)) val = true;

            return val;
        }
    }
}
