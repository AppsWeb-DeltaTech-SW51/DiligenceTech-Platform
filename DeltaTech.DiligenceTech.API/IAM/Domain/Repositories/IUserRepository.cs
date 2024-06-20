using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;

namespace DeltaTech.DiligenceTech.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}