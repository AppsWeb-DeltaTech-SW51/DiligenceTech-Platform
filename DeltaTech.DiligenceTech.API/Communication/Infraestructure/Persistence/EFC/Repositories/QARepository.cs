using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.Communication.Infraestructure.Persistence.EFC.Repositories;

public class QARepository(AppDbContext context) : BaseRepository<QA>(context), IQARepository
{
    public Task<QA?> FindQAByIdAsync(int Id)
    {
        return Context.Set<QA>().Where(QA => QA.Id == Id).FirstOrDefaultAsync();
    }
}