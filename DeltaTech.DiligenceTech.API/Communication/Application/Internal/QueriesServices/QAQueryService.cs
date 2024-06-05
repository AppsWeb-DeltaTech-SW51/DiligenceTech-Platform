using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Communication.Domain.Services;
using DeltaTech.DiligenceTech.API.Communication.Infraestructure.Persistence.EFC.Repositories;

namespace DeltaTech.DiligenceTech.API.Communication.Application.Internal.QueriesServices;

public class QAQueryService(IQARepository qaRepository) : IQAQueryService
{
    public async Task<IEnumerable<QA>> Handle(GetAllQASQuery query) => await qaRepository.ListAsync();
    

    public async Task<QA?> Handle(GetQAByIdQuery query)
    {
        return await qaRepository.FindByIdAsync(query.QAId);
    }
}