using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridSampleApp.Models
{
    public class EnumLabelPair<T>
        where T : struct
    {
        public T Enum { get; }
        public string Label { get; }

        public EnumLabelPair(T e, string label)
        {
            this.Enum = e;
            this.Label = label;
        }
    }

    public static class EnumLabelPair
    {
        public static IEnumerable<EnumLabelPair<T>> CreateFromDisplayAttribute<T>()
            where T : struct
        {
            return Enum.GetValues(typeof(T))
                .OfType<object>()
                .Select(x => (T)x)
                .Select(x => new EnumLabelPair<T>(
                    x,
                    ((DisplayAttribute)typeof(T).GetField(x.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault())?.Name));
        }
    }
}
