using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Documents;
using EasyDocs.Domain.Events.DocumentTypes;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.Documents;

public sealed class DocumentCommandHandler : CommandHandler<Document>,
    IRequestHandler<CreateDocumentCommand, CommandResult>,
    IRequestHandler<UpdateDocumentCommand, CommandResult>,
    IRequestHandler<DeleteDocumentCommand, CommandResult>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IUserRepository _userRepository;

    public DocumentCommandHandler(
        IDocumentRepository documentRepository,
        IDocumentTypeRepository documentTypeRepository,
        IClientRepository clientRepository,
        IUserRepository userRepository
        )
    {
        _documentRepository = documentRepository;
        _documentTypeRepository = documentTypeRepository;
        _clientRepository = clientRepository;
        _userRepository = userRepository;
    }


    public async Task<CommandResult> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        if (!await _clientRepository.ClientExists(command.ClientId))
        {
            AddNotification("Licensee", "Um licenciado com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _documentTypeRepository.DocumentTypeExists(command.DocumentTypeId))
        {
            AddNotification("DocumentType", "Um tipo de documento com esse Id não existe.");
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

        var description = new Description(command.Description);
        var source = new Source(command.Source);
        var document = new Document(
            Guid.NewGuid(),
            command.LicenseeId,
            command.CompanyId,
            command.DocumentTypeId,
            description,
            source,
            command.ExpirationDate,
            command.File,
            command.SpecificAccess
            );

        if (!document.IsValid) return new CommandResult(false, document.Notifications.ToList());

        if (await _documentRepository.GetOneWhere(d => d.File == document.File
        || d.Description.Text == document.Description.Text) is not null)
        {
            AddNotification("Document", "Um documento com o mesmo arquivo ou descrição já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        document.AddDomainEvent(new DocumentCreatedEvent(
            document.Id,
            document.LicenseeId,
            document.CompanyId,
            document.DocumentTypeId,
            document.Description,
            document.Source,
            document.ExpirationDate,
            document.File,
            document.SpecificAccess,
            user.Id,
            user.Username.ToString()!
            )
        );

        _documentRepository.Add(document);

        return await Commit(_documentRepository.UnitOfWork, "Documento criado com sucesso!");
    }

    public async Task<CommandResult> Handle(UpdateDocumentCommand command, CancellationToken cancellationToken)
    {
        var existentDocument = await _documentRepository.GetOneWhere(d => d.Id == command.Id);
        if (existentDocument is null)
        {
            AddNotification("Document", "Um documento com esse Id não existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        if (!await _documentTypeRepository.DocumentTypeExists(command.DocumentTypeId))
        {
            AddNotification("DocumentType", "Um tipo de documento com esse Id não existe.");
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

        var description = new Description(command.Description);
        var source = new Source(command.Source);
        var document = new Document(
            command.Id,
            command.LicenseeId,
            command.CompanyId,
            command.DocumentTypeId,
            description,
            source,
            command.ExpirationDate,
            command.File,
            command.SpecificAccess
            );

        document.Update(existentDocument.CreatedAt);

        if (!document.IsValid) return new CommandResult(false, document.Notifications.ToList());

        if (await _documentRepository.GetOneWhere(d => d.File == document.File
        || d.Description.Text == document.Description.Text && d.Id != document.Id) is not null)
        {
            AddNotification("Document", "Um documento com o mesmo arquivo ou descrição já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        document.AddDomainEvent(new DocumentCreatedEvent(
            document.Id,
            document.LicenseeId,
            document.CompanyId,
            document.DocumentTypeId,
            document.Description,
            document.Source,
            document.ExpirationDate,
            document.File,
            document.SpecificAccess,
            user.Id,
            user.Username.ToString()!
            )
        );

        _documentRepository.Update(document.Id, document);

        return await Commit(_documentRepository.UnitOfWork, "Documento criado com sucesso!");
    }

    public async Task<CommandResult> Handle(DeleteDocumentCommand command, CancellationToken cancellationToken)
    {
        var existentDocument = await _documentRepository.GetOneWhere(dt => dt.Id == command.Id);
        if (existentDocument is null)
        {
            AddNotification("Document", "Um documento com esse Id não existe.");
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

        existentDocument.Deactivate();

        if (!existentDocument.IsValid) return new CommandResult(false, existentDocument.Notifications.ToList());

        existentDocument.AddDomainEvent(new DocumentTypeDeletedEvent(existentDocument.Id, user.Id, user.Username.ToString()!));

        _documentRepository.Update(existentDocument.Id, existentDocument);

        return await Commit(_documentRepository.UnitOfWork, "Documento deletado com sucesso!");
    }
}