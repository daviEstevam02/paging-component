using EasyDocs.Domain.Commands.UserDocuments;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.UserDocuments;
using EasyDocs.Domain.Interfaces;
using MediatR;
using System.Xml.Linq;

namespace EasyDocs.Domain.Handlers.UserDocuments;

public sealed class UserDocumentCommandHandler : CommandHandler<UserDocument>,
    IRequestHandler<CreateUserDocumentCommand, CommandResult>,
    IRequestHandler<UpdateUserDocumentCommand, CommandResult>,
    IRequestHandler<DeleteUserDocumentCommand, CommandResult>

{
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserDocumentRepository _userDocumentRepository;



    public UserDocumentCommandHandler(
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUserDocumentRepository userDocument
        )
    {
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _userDocumentRepository = userDocument;
    }

    public async Task<CommandResult> Handle(CreateUserDocumentCommand command, CancellationToken cancellationToken)
    {
        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            AddNotification("Licensee", "Um licenciado com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }
        if (!await _companyRepository.CompanyExists(command.CompanyId))
        {
            AddNotification("Empresa", "Uma empresa com esse Id não existe.");
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

        var userDocument = new UserDocument(
            Guid.NewGuid(),
            user.Id,
            command.DocumentId,
            command.CompanyId,
            command.LicenseeId
        );

        if (!userDocument.IsValid) return new CommandResult(false, userDocument.Notifications.ToList());

        userDocument.AddDomainEvent(new UserDocumentCreatedEvent(
            userDocument.Id,
            user.Id,
            userDocument.DocumentId,
            userDocument.CompanyId,
            userDocument.LicenseeId,
            user.Username.ToString()));

        _userDocumentRepository.Add(userDocument);

        return await Commit(_userDocumentRepository.UnitOfWork, "Tipo de documento usuário criado com sucesso!");

    }

    public async Task<CommandResult> Handle(UpdateUserDocumentCommand command, CancellationToken cancellationToken)
    {
        var existentUserDocument = await _userDocumentRepository.GetOneWhere(dt => dt.Id == command.Id);
        if (existentUserDocument is null)
        {
            AddNotification("UserDocument", "Um tipo de documento usuário com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            AddNotification("Licensee", "Um licenciado com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _companyRepository.CompanyExists(command.CompanyId))
        {
            AddNotification("Empresa", "Uma empresa com esse Id não existe.");
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

        var userDocument = new UserDocument(
            Guid.NewGuid(),
            user.Id,
            command.DocumentId,
            command.CompanyId,
            command.LicenseeId
        );

        userDocument.Update(existentUserDocument.CreatedAt);
        if (!userDocument.IsValid) return new CommandResult(false, userDocument.Notifications.ToList());

        userDocument.AddDomainEvent(new UserDocumentCreatedEvent(
           userDocument.Id,
           user.Id,
           userDocument.DocumentId,
           userDocument.CompanyId,
           userDocument.LicenseeId,
           user.Username.ToString()));

        _userDocumentRepository.Update(userDocument.Id, userDocument);
        return await Commit(_userDocumentRepository.UnitOfWork, "Tipo de documento usuário atualizado com sucesso!");

    }

    public Task<CommandResult> Handle(DeleteUserDocumentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
