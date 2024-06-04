namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;

public record CreateProjectCommand(string Code, string Name, bool Confirmed);