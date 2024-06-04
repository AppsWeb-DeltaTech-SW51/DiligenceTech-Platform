using System.ComponentModel.DataAnnotations.Schema;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;

public partial class Project
{
    public int Id { get; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public bool Confirmed { get; private set; }
    
    public Project(string code, string name, bool confirmed)
    {
        Code = code;
        Name = name;
        Confirmed = confirmed;
    }
    
    public Project(CreateProjectCommand command)
    {
        Code = command.Code;
        Name = command.Name;
        Confirmed = command.Confirmed;
    }
}