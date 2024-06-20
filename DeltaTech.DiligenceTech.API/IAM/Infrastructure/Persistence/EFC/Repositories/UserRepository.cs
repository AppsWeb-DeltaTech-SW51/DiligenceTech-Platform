using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.IAM.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository 
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}