using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace A_Mapping2.Views
{
    class ProgressBarWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Converter o valor para largura proporcional
            double progress = (double)value;
            double maxValue = 100; // O valor máximo da ProgressBar
            return (progress / maxValue) * 250; // Largura máxima de 250
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
