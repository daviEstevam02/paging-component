using EasyDocs.Domain.Core.Transactions;
using EasyDocs.Infra.Data.Context;

namespace EasyDocs.Infra.Data.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly EasyDocsContext _context;

    public UnitOfWork(EasyDocsContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit() => await _context.SaveChangesAsync() > 0;
}