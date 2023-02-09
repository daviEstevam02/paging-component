using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Documents;
using EasyDocs.Domain.Events.DocumentTypes;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace EasyDocs.Domain.Handlers.DocumentTypes;

public sealed class DocumentTypeCommandHandler : CommandHandler<DocumentTypeCommandHandler>,
    IRequestHandler<CreateDocumentTypeCommand, CommandResult>
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
            command.AddNotification("Licensee", "Um licenciado com esse Id não existe.");
            return new CommandResult(false, command.Notifications.ToList());
        }

        if (!await _companyRepository.CompanyExists(command.CompanyId))
        {
            command.AddNotification("Empresa", "Uma empresa com esse Id não existe.");
            return new CommandResult(false, command.Notifications.ToList());
        }

        var user = await _userRepository.GetOneWhere(u => u.Id == command.UserId);
        if (user is null)
        {
            command.AddNotification("User", "Um usuário com esse Id não existe.");
            return new CommandResult(false, command.Notifications.ToList());
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
            documentType.AddNotification("DocumentType", "Um tipo de documento com a mesma descrição e grupo já existe.");
            return new CommandResult(false, documentType.Notifications.ToList());
        }

        documentType.AddDomainEvent(new DocumentTypedCreatedEvent(
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
}