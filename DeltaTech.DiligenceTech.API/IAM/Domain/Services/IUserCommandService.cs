using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}