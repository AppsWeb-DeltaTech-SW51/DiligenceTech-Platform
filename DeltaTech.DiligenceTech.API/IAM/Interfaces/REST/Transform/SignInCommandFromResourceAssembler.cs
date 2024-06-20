using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.IAM.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}