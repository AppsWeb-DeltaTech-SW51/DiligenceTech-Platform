using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;

namespace DeltaTech.DiligenceTech.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}