using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Queries;

namespace DeltaTech.DiligenceTech.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}