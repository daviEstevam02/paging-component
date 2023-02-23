using EasyDocs.Domain.Commands.Users;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Users;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.Users;

public sealed class UserCommandHandler : CommandHandler<User>,
    IRequestHandler<CreateUserCommand, CommandResult>,
    IRequestHandler<UpdateUserCommand, CommandResult>,
    IRequestHandler<DeleteUserCommand, CommandResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IClientRepository _clientRepository;

    public UserCommandHandler(
        IClientRepository clientRepository,
        IUserRepository userRepository)
    {
        _clientRepository = clientRepository;
        _userRepository = userRepository;
    }

    public async Task<CommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (!await _clientRepository.ClientExists(command.ClientId))
        {
            AddNotification("Client", $"Um cliente com o Id {command.ClientId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var userForLogExists = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (userForLogExists is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.UserId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        var username = new Username(command.Username);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var user = new User(
            Guid.NewGuid(),
            command.ClientId,
            command.UserType,
            command.LinkCode,
            command.DocumentGroup,
            username,
            email,
            password
            );

        if (!user.IsValid) return new CommandResult(false, user.Notifications.ToList());

        if (await _userRepository.GetOneWhere(d => d.Email.Address == user.Email.Address) is not null)
        {
            AddNotification("User", "Um usuário com o mesmo email já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        user.AddDomainEvent(new UserCreatedEvent(
            user.Id,
            user.ClientId,
            user.UserType,
            user.LinkCode,
            user.DocumentGroup,
            user.Username,
            user.Email,
            user.Password,
            userForLogExists.Id,
            userForLogExists.Username.ToString()!
            )
        );

        _userRepository.Add(user);

        return await Commit(_userRepository.UnitOfWork, "Usuário criado com sucesso!");
    }

    public async Task<CommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        if (!await _clientRepository.ClientExists(command.ClientId))
        {
            AddNotification("Client", $"Um cliente com o Id {command.ClientId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var userForLogExists = await _userRepository.GetOneWhere(ut => ut.Id == command.UserId);
        if (userForLogExists is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.UserId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var existentUser = await _userRepository.GetOneWhere(u => u.Id == command.Id);
        if (existentUser is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.Id} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        var username = new Username(command.Username);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var user = new User(
            existentUser.Id,
            command.ClientId,
            command.UserType,
            command.LinkCode,
            command.DocumentGroup,
            username,
            email,
            password
            );

        user.Update(existentUser.CreatedAt);

        if (!user.IsValid) return new CommandResult(false, user.Notifications.ToList());

        if (await _userRepository.GetOneWhere(d => d.Username.Nickname == user.Username.Nickname
        && d.Id != user.Id) is not null)
        {
            AddNotification("User", "Um usuário com o mesmo nome de usuário já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        user.AddDomainEvent(new UserUpdatedEvent(
            user.Id,
            user.ClientId,
            user.UserType,
            user.LinkCode,
            user.DocumentGroup,
            user.Username,
            user.Email,
            user.Password,
            userForLogExists.Id,
            userForLogExists.Username.ToString()!)
            );

        _userRepository.Update(existentUser.Id, user);

        return await Commit(_userRepository.UnitOfWork, "Usuário atualizado com sucesso!");
    }

    public async Task<CommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var userForLogExists = await _userRepository.GetOneWhere(ut => ut.Id == command.Id);
        if (userForLogExists is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.UserId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var existentUser = await _userRepository.GetOneWhere(u => u.Id == command.Id);
        if (existentUser is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.Id} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        existentUser.Deactivate();

        if (!existentUser.IsValid) return new CommandResult(false, existentUser.Notifications.ToList());

        existentUser.AddDomainEvent(new UserDeletedEvent(existentUser.Id, userForLogExists.Id, userForLogExists.Username.ToString()!));

        _userRepository.Update(existentUser.Id, existentUser);

        return await Commit(_userRepository.UnitOfWork, "Usuário deletado com sucesso!");
    }
}