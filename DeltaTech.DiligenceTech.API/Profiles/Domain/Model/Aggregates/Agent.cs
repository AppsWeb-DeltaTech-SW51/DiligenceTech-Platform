using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;

public class Agent
{
    public int Id { get; }
    public string Code { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Image { get; private set; }
    
    public Agent(string code, string email, string username, string password, string image)
    {
        this.Code = code;
        this.Email = email;
        this.Username = username;
        this.Password = password;
        this.Image = image;
    }

    public Agent(CreateAgentCommand command)
    {
        this.Code = command.Code;
        this.Email = command.Email;
        this.Username = command.Username;
        this.Password = command.Password;
        this.Image = command.Image;
    }
}