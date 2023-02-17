using EasyDocs.Domain.Commands.UserTypes;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.DocumentTypes;
using EasyDocs.Domain.Events.UserTypes;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.UserTypes;

public sealed class UserTypeCommandHandler : CommandHandler<UserType>,
    IRequestHandler<CreateUserTypeCommand, CommandResult>,
    IRequestHandler<UpdateUserTypeCommand, CommandResult>,
    IRequestHandler<DeleteUserTypeCommand, CommandResult>
{
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserTypeRepository _userTypeRepository;
    private readonly IUserRepository _userRepository;

    public UserTypeCommandHandler(
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserTypeRepository userTypeRepository,
        IUserRepository userRepository)
    {
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userTypeRepository = userTypeRepository;
        _userRepository = userRepository;
    }

    public async Task<CommandResult> Handle(CreateUserTypeCommand command, CancellationToken cancellationToken)
    {
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

        var user = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (user is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.UserId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        var description = new Description(command.Description);
        var role = new Role(command.CanRead, command.CanWrite, command.CanUpdate, command.CanDelete);
        var userType = new UserType(
            Guid.NewGuid(),
            command.LicenseeId,
            command.CompanyId,
            command.ErpUserType,
            description,
            role
            );

        if (!userType.IsValid) return new CommandResult(false, userType.Notifications.ToList());

        if (await _userTypeRepository.GetOneWhere(d => d.Description.Text == userType.Description.Text) is not null)
        {
            AddNotification("UserType", "Um tipo de usuário com a mesma descrição já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        userType.AddDomainEvent(new UserTypeCreatedEvent(
            userType.Id,
            userType.LicenseeId,
            userType.CompanyId,
            userType.ErpUserType,
            userType.Description,
            userType.Roles,
            user.Id,
            user.Username.ToString()!
            )
        );

        _userTypeRepository.Add(userType);

        return await Commit(_userTypeRepository.UnitOfWork, "Tipo de usuário criado com sucesso!");
    }

    public async Task<CommandResult> Handle(UpdateUserTypeCommand command, CancellationToken cancellationToken)
    {
        var existentUserType = await _userTypeRepository.GetOneWhere(ut => ut.Id == command.Id);
        if (existentUserType is null)
        {
            AddNotification("UserType", $"Um tipo de usuário com o Id {command.Id} não existe.");
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

        var user = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (user is null)
        {
            AddNotification("User", $"Um usuário com o Id {command.UserId} não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        var description = new Description(command.Description);
        var roles = new Role(command.CanRead, command.CanWrite, command.CanUpdate, command.CanDelete);
        var userType = new UserType(
            existentUserType.Id,
            command.LicenseeId,
            command.CompanyId,
            command.ErpUserType,
            description,
            roles
            );

        userType.Update(existentUserType.CreatedAt);

        if (!userType.IsValid) return new CommandResult(false, userType.Notifications.ToList());

        if (await _userTypeRepository.GetOneWhere(d => d.Description.Text == userType.Description.Text 
        && d.Id != userType.Id) is not null)
        {
            AddNotification("UserType", "Um tipo de usuário com a mesma descrição e grupo já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        userType.AddDomainEvent(new UserTypeUpdatedEvent(
            userType.Id,
            userType.LicenseeId,
            userType.CompanyId,
            userType.ErpUserType,
            userType.Description,
            userType.Roles,
            user.Id,
            user.Username.ToString()!)
            );

        _userTypeRepository.Update(existentUserType.Id, userType);

        return await Commit(_userTypeRepository.UnitOfWork, "Tipo de usuário atualizado com sucesso!");
    }

    public async Task<CommandResult> Handle(DeleteUserTypeCommand command, CancellationToken cancellationToken)
    {
        var existentUserType = await _userTypeRepository.GetOneWhere(ut => ut.Id == command.Id);
        if (existentUserType is null)
        {
            AddNotification("UserType", "Um tipo de usuário com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        var user = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (user is null)
        {
            AddNotification("User", "Um usuário com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        command.Validate();
        if (!command.IsValid) return new CommandResult(false, command.Notifications.ToList());

        existentUserType.Deactivate();

        if (!existentUserType.IsValid) return new CommandResult(false, existentUserType.Notifications.ToList());

        existentUserType.AddDomainEvent(new DocumentTypeDeletedEvent(existentUserType.Id, user.Id, user.Username.ToString()!));

        _userTypeRepository.Update(existentUserType.Id, existentUserType);

        return await Commit(_userTypeRepository.UnitOfWork, "Tipo de usuário deletado com sucesso!");
    }
}