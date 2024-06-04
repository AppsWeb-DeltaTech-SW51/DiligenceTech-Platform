using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeltaTech.DiligenceTech.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/**
 * <summary>
 * Extension method to get error messages from a model state dictionary.
 * Class with method to get error messages from KebabCaseRouteNamingConventions.
 * </summary>
 */
public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}