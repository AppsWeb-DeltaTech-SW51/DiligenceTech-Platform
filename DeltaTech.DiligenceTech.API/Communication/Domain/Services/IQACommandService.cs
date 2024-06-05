using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.Communication.Domain.Services;

public interface IQACommandService
{
    Task<QA?> Handle(CreateQACommand command);
}