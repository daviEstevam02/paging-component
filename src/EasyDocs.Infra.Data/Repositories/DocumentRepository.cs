using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(EasyDocsContext context) 
        : base(context)
    { }

    public override async Task<IEnumerable<Document>> GetAll(Expression<Func<Document, bool>> condition)
        => await _dbSet
        .Include(d => d.Company)
        .ThenInclude(c => c.Licensee)
        .Include(d => d.DocumentType)
        .Where(condition)
        .ToListAsync();

    public override async Task<Document> GetOneWhere(Expression<Func<Document, bool>> condition)
        => (await _dbSet
        .Include(d => d.Company)
        .ThenInclude(c => c.Licensee)
        .Include(d => d.DocumentType)
        .SingleOrDefaultAsync(condition))!;
}