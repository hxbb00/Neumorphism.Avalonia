#nullable enable
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Neumorphism.Demo.Converters {
    public class StringJoinConverter : IValueConverter {
        public string? Separator { get; set; }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            IEnumerable values = value as IEnumerable ?? Array.Empty<object>();
            return string.Join(Separator ?? "", values.OfType<object>());
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}