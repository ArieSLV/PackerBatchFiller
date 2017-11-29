using System;
using System.Globalization;
using System.Windows;

namespace PacketBatchFiller4
{
    /// <inheritdoc cref="BaseValueConverter{T}"/>
    /// <summary>
    /// Конвертирует <value><see cref="bool"/></value> в <returns><see cref="Visibility"/></returns>:
    /// <para />true == <see cref="F:System.Windows.Visibility.Visible" />, false == <see cref="F:System.Windows.Visibility.Collapsed" />
    /// </summary>
    internal class BoolToVisibilityVisible : BaseValueConverter<BoolToVisibilityVisible>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            return (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}