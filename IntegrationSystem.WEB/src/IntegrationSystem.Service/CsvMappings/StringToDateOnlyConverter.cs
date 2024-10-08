using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace IntegrationSystem.Service.CsvMappings;

/// <summary>
/// Converts <see cref="DateOnly"/> values to and from their string representations for CSV processing.
/// </summary>
public class StringToDateOnlyConverter: ITypeConverter
{
    /// <summary>
    /// Converts a string value to a <see cref="DateOnly"/> object.
    /// </summary>
    /// <param name="text">The string representation of the date.</param>
    /// <param name="row">The current <see cref="IReaderRow"/> context.</param>
    /// <param name="memberMapData">Metadata about the member being mapped.</param>
    /// <returns>The <see cref="DateOnly"/> representation of the string.</returns>
    /// <exception cref="CsvHelperException">Thrown when the date format is invalid.</exception>
    public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        var formats = new[] { "dd/MM/yyyy", "d/M/yyyy" }; // Handles both single and double digit day/month
        foreach (var format in formats)
        {
            if (DateOnly.TryParseExact(text, format, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        throw new CsvHelperException(row.Context, $"Invalid date format for '{text}'");
    }

    /// <summary>
    /// Converts a <see cref="DateOnly"/> object to its string representation.
    /// </summary>
    /// <param name="value">The <see cref="DateOnly"/> value to convert.</param>
    /// <param name="row">The current <see cref="IWriterRow"/> context.</param>
    /// <param name="memberMapData">Metadata about the member being mapped.</param>
    /// <returns>The string representation of the <see cref="DateOnly"/> value.</returns>
    public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value is DateOnly date)
        {
            return date.ToString("yyyy-MM-dd"); // Specify desired date format
        }
        return string.Empty;
    }
}