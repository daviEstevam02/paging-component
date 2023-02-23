using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(EasyDocsContext context) : base(context)
    { }

    public async Task<bool> ClientExists(Guid clientId)
        => await _dbSet.SingleOrDefaultAsync(c => c.Id == clientId) is not null;
}