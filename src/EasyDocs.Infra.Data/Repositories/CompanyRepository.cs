using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(EasyDocsContext context)
        : base(context)
    { }

    public async Task<bool> CompanyExists(Guid id)
        => await GetOneWhere(company => company.Id == id) is not null;
}