using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Core.Transactions;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Events.Companies;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Domain.ValueObjects;
using Gooders.Shared.Core.Commands;
using MediatR;

namespace EasyDocs.Domain.Handlers.Companies;

public sealed class CompanyCommandHandler :
    IRequestHandler<CreateCompanyCommand, CommandResult>
{
    private readonly ILicenseeRepository _licenseeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyCommandHandler(
        ILicenseeRepository licenseeRepository,
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
        )
    {
        _licenseeRepository = licenseeRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommandResult> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        if (!await _licenseeRepository.LicenseeExists(command.LicenseeId))
        {
            command.AddNotification("Licensee", "Um licenciado com esse Id não existe.");
            return new CommandResult(false, command.Notifications.ToList());
        }

        var userId = command.UserId;
        if (!await _userRepository.UserExists(userId))
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

        if (await _companyRepository.GetOneWhere(d => d.Cnpj == company.Cnpj) is not null)
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
            userId)
        );

        await _companyRepository.Add(company);

        if (!await _unitOfWork.Commit())
        {
            company.AddNotification("Company", "Erro ao salvar a empresa.");
            return new CommandResult(false, company.Notifications.ToList());
        }

        return new CommandResult(true, "Empresa criada com sucesso!");
    }
}