using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.IAM.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}