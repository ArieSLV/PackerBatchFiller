
using System;
using System.Globalization;
using System.Windows;

namespace PacketBatchFiller4
{

    /// <inheritdoc />
    /// <summary>
    /// Конвертирует количество в <see cref="Visibility"/>: еденица конвертируется в <see cref="F:System.Windows.Visibility.Collapsed" />, остальное в <see cref="F:System.Windows.Visibility.Visible" />
    /// </summary>
    internal class IntOneToVisibilityCollapsed : BaseValueConverter<IntOneToVisibilityCollapsed>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var v = (int) value;
            return v == 1 ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
