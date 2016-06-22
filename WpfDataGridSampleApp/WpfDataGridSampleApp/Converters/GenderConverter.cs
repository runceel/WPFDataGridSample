using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.Converters
{
    public class GenderConverter : IValueConverter
    {
        private Dictionary<string, Gender> NameToGenderMap { get; }

        public GenderConverter()
        {
            this.NameToGenderMap = Enum.GetValues(typeof(Gender))
                .OfType<Gender>()
                .Select(x => new { Value = x, FieldInfo = typeof(Gender).GetField(x.ToString()) })
                .Select(x => new { x.Value, Attribute = x.FieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().First() })
                .ToDictionary(x => x.Attribute.Name, x => x.Value);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .Select(x => x.Name)
                .First();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.NameToGenderMap[(string)value];
        }
    }
}
