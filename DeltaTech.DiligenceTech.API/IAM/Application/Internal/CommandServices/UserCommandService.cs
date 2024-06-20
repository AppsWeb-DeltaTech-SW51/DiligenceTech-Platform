using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Application.Internal.OutboundServices;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.IAM.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.IAM.Domain.Repositories;
using DeltaTech.DiligenceTech.API.IAM.Domain.Services;

namespace DeltaTech.DiligenceTech.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IHashingService hashingService,
    ITokenService tokenService,
    IUnitOfWork unitOfWork
    ) : IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}