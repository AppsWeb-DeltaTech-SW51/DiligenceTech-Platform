using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Transform;

public class QAResourceFromEntityAssembler
{
    public static QAResource ToResourceFromEntity(QA entity)
    {
        return new QAResource(entity.Id, entity.Content);
    }
}