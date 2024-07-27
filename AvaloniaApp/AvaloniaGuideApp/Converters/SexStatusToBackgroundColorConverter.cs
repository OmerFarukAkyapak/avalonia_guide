using Avalonia.Data.Converters;
using Avalonia.Media;
using AvaloniaGuideApp.Models;
using System;
using System.Globalization;

namespace AvaloniaGuideApp.Converters
{
    public class SexStatusToBackgroundColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is SexTypes sex)
            {
                return sex switch
                {
                    SexTypes.Male => Brushes.LightBlue,
                    SexTypes.Female => Brushes.LightPink,
                    _ => Brushes.LightGray
                };
            }
            return Brushes.LightGray;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
