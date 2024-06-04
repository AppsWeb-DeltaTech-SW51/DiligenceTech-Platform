namespace DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}