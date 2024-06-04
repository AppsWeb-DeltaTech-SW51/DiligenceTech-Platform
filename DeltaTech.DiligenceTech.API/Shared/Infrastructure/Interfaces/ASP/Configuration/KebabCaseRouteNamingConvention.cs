using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DeltaTech.DiligenceTech.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/**
 * <summary>
 * this class represents a kebab case routing convention.
 * It's used for endpoints' route names.
 * </summary>
 */
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
 
 /**
     * <summary>
     * This method replaces the controller template.
     * </summary>
     * <param name="selector">The selector model.</param>
     * <param name="name">The name of the controller.</param>
     * <returns>The attribute route model.</returns>
 */
 private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
 {
  return selector.AttributeRouteModel != null
   ? new AttributeRouteModel
   {
    Template = selector.AttributeRouteModel.Template?.Replace("[Controller]", name.ToKebabCase())
   } : null;
 }
 
 /**
     * <summary>
     * This method applies the kebab case route naming convention.
     * </summary>
     * <param name="controller">The controller model.</param>
 */
 public void Apply(ControllerModel controller)
 {
  foreach (var selector in controller.Selectors)
  {
   selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
  }

  foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
  {
   selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
  }
 }
}