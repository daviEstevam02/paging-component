using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class LicenseeRepository : BaseRepository<Licensee>, ILicenseeRepository
{
    public LicenseeRepository(EasyDocsContext context) 
        : base(context)
    { }

    public async Task<bool> LicenseeExists(Guid id)
        => await GetOneWhere(licensee => licensee.Id == id) is not null;
}