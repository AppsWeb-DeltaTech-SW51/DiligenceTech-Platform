using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Queries;

namespace DeltaTech.DiligenceTech.API.Communication.Domain.Services;

public interface IQAQueryService
{
    Task<IEnumerable<QA>> Handle(GetAllQASQuery query);
    Task<QA?> Handle(GetQAByIdQuery query);
}