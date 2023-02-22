using EasyDocs.Domain.Commands.UserDocuments;
using EasyDocs.Domain.Commands.Users;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.DocumentTypes;
using EasyDocs.Domain.Events.Users;
using EasyDocs.Domain.Events.UserTypes;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EasyDocs.Domain.Handlers.Users;

public sealed class UserCommandHandler : CommandHandler<User>,
    IRequestHandler<CreateUserCommand, CommandResult>,
    IRequestHandler<UpdateUserCommand, CommandResult>,
    IRequestHandler<DeleteUserCommand, CommandResult>
{
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserTypeRepository _userTypeRepository;

    public UserCommandHandler(
        ILicenseeRepository licenseeRepository, 
        ICompanyRepository companyRepository, 
        IUserRepository userRepository,
        IUserTypeRepository userTypeRepository)
    {
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _userTypeRepository = userTypeRepository;
    }

    public async Task<CommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (!await _userTypeRepository.UserTypeExists(command.UserTypeId))
        {
            AddNotification("UserType", $"Um tipo de usuário com o Id {command.UserTypeId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            AddNotification("Licensee", $"Um licenciado com o Id {command.LicenseeId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _companyRepository.CompanyExists(command.CompanyId))
        {
            AddNotification("Company", $"Uma empresa com o Id {command.CompanyId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var userExists = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (userExists is null)
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
            command.LicenseeId,
            command.CompanyId,
            command.UserTypeId,
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
            user.LicenseeId,
            user.CompanyId,
            user.UserTypeId,
            user.LinkCode,
            user.DocumentGroup,
            user.Username,
            user.Email,
            user.Password,
            userExists.Id,
            userExists.Username.ToString()!
            )
        );

        _userRepository.Add(user);

        return await Commit(_userRepository.UnitOfWork, "Usuário criado com sucesso!");
    }

    public async Task<CommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var existentUser = await _userTypeRepository.GetOneWhere(ut => ut.Id == command.Id);
        if (existentUser is null)
        {
            AddNotification("UserType", $"Um tipo de usuário com o Id {command.Id} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _userTypeRepository.UserTypeExists(command.UserTypeId))
        {
            AddNotification("UserType", $"Um tipo de usuário com o Id {command.UserTypeId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            AddNotification("Licensee", $"Um licenciado com o Id {command.LicenseeId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _companyRepository.CompanyExists(command.CompanyId))
        {
            AddNotification("Company", $"Uma empresa com o Id {command.CompanyId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var userExists = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (userExists is null)
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
            existentUser.Id,
            command.LicenseeId,
            command.CompanyId,
            command.UserTypeId,
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
            user.LicenseeId,
            user.CompanyId,
            user.UserTypeId,
            user.LinkCode,
            user.DocumentGroup,
            user.Username,
            user.Email,
            user.Password,
            userExists.Id,
            userExists.Username.ToString()!)
            );

        _userRepository.Update(existentUser.Id, user);

        return await Commit(_userRepository.UnitOfWork, "Usuário atualizado com sucesso!");
    }

    public async Task<CommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var existentUser = await _userRepository.GetOneWhere(ut => ut.Id == command.Id);
        if (existentUser is null)
        {
            AddNotification("UserType", "Um tipo de usuário com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var userExists = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (userExists is null)
        {
            AddNotification("User", "Um usuário com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        existentUser.Deactivate();

        if (!existentUser.IsValid) return new CommandResult(false, existentUser.Notifications.ToList());

        existentUser.AddDomainEvent(new UserDeletedEvent(existentUser.Id, userExists.Id, userExists.Username.ToString()!));

        _userRepository.Update(existentUser.Id, existentUser);

        return await Commit(_userRepository.UnitOfWork, "Usuário deletado com sucesso!");
    }
}