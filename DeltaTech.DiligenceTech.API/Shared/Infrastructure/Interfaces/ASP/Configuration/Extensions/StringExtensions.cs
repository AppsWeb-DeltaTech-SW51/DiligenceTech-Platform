using System.Text.RegularExpressions;

namespace DeltaTech.DiligenceTech.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/**
 * <summary>
 * Class of methods for KebabCaseRouteNamingConvention.cs
 * </summary>
 */
public static partial class StringExtensions
{
    // This regex pattern is used to convert a string to kebab case
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();

    /**
     * <summary>
     * This method converts a string to kebab case.
     * </summary>
     * <param name="text">The text to convert to kebab case.</param>
     * <returns>The text converted to kebab case.</returns>
     */
    public static string ToKebabCase(this string text)
    {
        // if this text is null or empty, return the text. Otherwise, convert it
        return string.IsNullOrEmpty(text) ? text : KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }
}