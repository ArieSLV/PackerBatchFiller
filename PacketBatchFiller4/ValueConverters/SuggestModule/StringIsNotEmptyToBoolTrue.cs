using System;
using System.Globalization;

namespace PacketBatchFiller4
{
    /// <inheritdoc cref="BaseValueConverter{T}"/>
    /// <summary>
    /// Конвертирует <see cref="string"/> в <see cref="bool"/>: <para />
    ///     not empty == true, empty == false.
    /// </summary>
    internal class StringIsNotEmptyToBoolTrue : BaseValueConverter<StringIsNotEmptyToBoolTrue>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var v = ((string) value).Length;
            return v > 0;
        }
    }
}
