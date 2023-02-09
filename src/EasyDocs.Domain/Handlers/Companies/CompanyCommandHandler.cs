using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Handlers;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Companies;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using MediatR;

namespace EasyDocs.Domain.Handlers.Companies;

public sealed class CompanyCommandHandler : CommandHandler<Company>,
    IRequestHandler<CreateCompanyCommand, CommandResult>
{
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;

    public CompanyCommandHandler(
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserRepository userRepository
        )
    {
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    public async Task<CommandResult> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            command.AddNotification("Licensee", "Um licenciado com esse Id não existe.");
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

        var fantasyName = new FantasyName(command.FantasyName);
        var legalName = new LegalName(command.LegalName);
        var address = new Address(command.Country, command.State, command.City, command.Neighborhood, command.Street, command.Number, command.Compliment);
        var contact = new Phone(command.Contact);
        var cnpj = new CNPJ(command.Cnpj);
        var company = new Company(
            Guid.NewGuid(),
            command.LicenseeId,
            fantasyName,
            legalName,
            address,
            contact,
            cnpj,
            command.IsHeadquarter
        );

        if (!company.IsValid) return new CommandResult(false, company.Notifications.ToList());

        if (await _companyRepository.GetOneWhere(d => d.Cnpj.Number == company.Cnpj.Number) is not null)
        {
            company.AddNotification("Company", "Uma empresa com o mesmo CNPJ já existe.");
            return new CommandResult(false, company.Notifications.ToList());
        }

        company.AddDomainEvent(new CompanyCreatedEvent(
            company.Id,
            company.LicenseeId,
            company.FantasyName,
            company.LegalName,
            company.Address,
            company.Contact,
            company.Cnpj,
            company.IsHeadquarter,
            user.Id,
            user.Username.ToString()!
            )
        );

        _companyRepository.Add(company);

        return await Commit(_companyRepository.UnitOfWork, "Empresa criada com sucesso!");
    }
}