namespace DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;

public record CreateAgentCommand(string Code, string Email, string Username, string Password, string Image);