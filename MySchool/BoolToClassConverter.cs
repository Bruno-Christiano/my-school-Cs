using System;
using System.Collections;
using System.Globalization;
using Avalonia.Data.Converters;

namespace MySchool;

public class BoolToClassConverter:IValueConverter
{
    
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
       
        if (value is bool isValid && !isValid)
        {
            Console.WriteLine(isValid);
            
            return "invalid";
        }

        return "valid";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}