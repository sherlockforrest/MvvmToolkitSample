using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MvvmToolkit;

public class TaskResultConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Task<string> val && val.IsCompleted)
        {
            return val.Result;
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}