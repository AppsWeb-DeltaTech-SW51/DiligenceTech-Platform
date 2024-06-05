using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;

public interface IQARepository : IBaseRepository<QA>
{
    Task<QA?> FindQAByIdAsync(int QAId);
}