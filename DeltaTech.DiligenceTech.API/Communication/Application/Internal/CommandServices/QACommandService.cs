using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.Communication.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Communication.Domain.Services;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.Communication.Application.Internal.CommandServices;

public class QACommandService(IQARepository qaRepository, IUnitOfWork unitOfWork) :IQACommandService
{
    public async Task<QA?> Handle(CreateQACommand command)
    {
        var qa = new QA(command);

        try
        {
            await qaRepository.AddAsync(qa);
            await unitOfWork.CompleteAsync();
            return qa;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error has ocurred while creating QA:{e.Message}");
            return null;
        }
    }
}