using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.DocumentTypes;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.DocumentTypes;

public sealed class DocumentTypeCommandHandler : CommandHandler<DocumentType>,
    IRequestHandler<CreateDocumentTypeCommand, CommandResult>,
    IRequestHandler<UpdateDocumentTypeCommand, CommandResult>,
    IRequestHandler<DeleteDocumentTypeCommand, CommandResult>
{
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;

    public DocumentTypeCommandHandler(
        IDocumentTypeRepository documentTypeRepository,
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserRepository userRepository
        )
    {
        _documentTypeRepository = documentTypeRepository;
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    public async Task<CommandResult> Handle(CreateDocumentTypeCommand command, CancellationToken cancellationToken)
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

        var description = new Description(command.Description);
        var documentType = new DocumentType(
            Guid.NewGuid(),
            command.LicenseeId,
            command.CompanyId,
            command.DocumentGroup,
            description
            );

        if (!documentType.IsValid) return new CommandResult(false, documentType.Notifications.ToList());

        if (await _documentTypeRepository.GetOneWhere(d => d.Description.Text == documentType.Description.Text
        && d.DocumentGroup == documentType.DocumentGroup) is not null)
        {
            AddNotification("DocumentType", "Um tipo de documento com a mesma descrição e grupo já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        documentType.AddDomainEvent(new DocumentTypeCreatedEvent(
            documentType.Id,
            documentType.LicenseeId,
            documentType.CompanyId,
            documentType.DocumentGroup,
            documentType.Description,
            user.Id,
            user.Username.ToString()!)
            );

        _documentTypeRepository.Add(documentType);

        return await Commit(_documentTypeRepository.UnitOfWork, "Tipo de documento criado com sucesso!");
    }

    public async Task<CommandResult> Handle(UpdateDocumentTypeCommand command, CancellationToken cancellationToken)
    {
        var existentDocumentType = await _documentTypeRepository.GetOneWhere(dt => dt.Id == command.Id);
        if (existentDocumentType is null)
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
        var documentType = new DocumentType(
            existentDocumentType.Id,
            command.LicenseeId,
            command.CompanyId,
            command.DocumentGroup,
            description
            );

        documentType.Update(existentDocumentType.CreatedAt);

        if (!documentType.IsValid) return new CommandResult(false, documentType.Notifications.ToList());

        if (await _documentTypeRepository.GetOneWhere(d => d.Description.Text == documentType.Description.Text
        && d.DocumentGroup == documentType.DocumentGroup && d.Id != documentType.Id) is not null)
        {
            AddNotification("DocumentType", "Um tipo de documento com a mesma descrição e grupo já existe.");
            return new CommandResult(false, Notifications.ToList());
        }

        documentType.AddDomainEvent(new DocumentTypeUpdatedEvent(
            documentType.Id,
            documentType.LicenseeId,
            documentType.CompanyId,
            documentType.DocumentGroup,
            documentType.Description,
            user.Id,
            user.Username.ToString()!)
            );

        _documentTypeRepository.Update(documentType.Id, documentType);

        return await Commit(_documentTypeRepository.UnitOfWork, "Tipo de documento atualizado com sucesso!");
    }

    public async Task<CommandResult> Handle(DeleteDocumentTypeCommand command, CancellationToken cancellationToken)
    {
        var existentDocumentType = await _documentTypeRepository.GetOneWhere(dt => dt.Id == command.Id);
        if (existentDocumentType is null)
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

        existentDocumentType.Deactivate();

        if (!existentDocumentType.IsValid) return new CommandResult(false, existentDocumentType.Notifications.ToList());

        existentDocumentType.AddDomainEvent(new DocumentTypeDeletedEvent(existentDocumentType.Id, user.Id, user.Username.ToString()!));

        _documentTypeRepository.Update(existentDocumentType.Id, existentDocumentType);

        return await Commit(_documentTypeRepository.UnitOfWork, "Tipo de documento deletado com sucesso!");
    }
}