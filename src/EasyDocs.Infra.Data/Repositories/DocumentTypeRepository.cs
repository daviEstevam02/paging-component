using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class DocumentTypeRepository : BaseRepository<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(EasyDocsContext context) : base(context)
    { }

    public async Task<bool> DocumentTypeExists(Guid id)
        => await _dbSet.SingleOrDefaultAsync(dt => dt.Id == id) is not null;

    public override async Task<DocumentType> GetOneWhere(Expression<Func<DocumentType, bool>> condition)
        => (await _dbSet
        .Include(dt => dt.Company)
        .ThenInclude(c => c.Licensee)
        .SingleOrDefaultAsync(condition))!;

    public override async Task<IEnumerable<DocumentType>> GetAll(Expression<Func<DocumentType, bool>> condition)
        => await _dbSet
        .Include(dt => dt.Company)
        .ThenInclude(c => c.Licensee)
        .Where(condition)
        .ToListAsync();
}