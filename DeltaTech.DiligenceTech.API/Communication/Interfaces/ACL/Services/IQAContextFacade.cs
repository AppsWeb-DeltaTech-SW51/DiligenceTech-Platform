namespace DeltaTech.DiligenceTech.API.Communication.Interfaces.ACL.Services;

public interface IQAContextFacade
{
    Task<int> CreateQA(string content, int Id);
    Task<int> FetchQAContentById(int Id);
}