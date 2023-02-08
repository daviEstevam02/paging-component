using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Documents;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.Documents;

public sealed class DocumentCommandHandler : CommandHandler<DocumentCommandHandler>,
    IRequestHandler<CreateDocumentCommand, CommandResult>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;

    public DocumentCommandHandler(
        IDocumentRepository documentRepository,
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserRepository userRepository
        )
    {
        _documentRepository = documentRepository;
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    public async Task<CommandResult> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
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
            document.AddNotification("Document", "Um documento com o mesmo arquivo ou descrição já existe.");
            return new CommandResult(false, document.Notifications.ToList());
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
}