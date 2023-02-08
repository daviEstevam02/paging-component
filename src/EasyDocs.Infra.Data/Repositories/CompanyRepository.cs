using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(EasyDocsContext context)
        : base(context)
    { }

    public async Task<bool> CompanyExists(Guid id)
        => await GetOneWhere(company => company.Id == id) is not null;

    public override async Task<IEnumerable<Company>> GetAll(Expression<Func<Company, bool>> condition)
        => await _dbSet
        .Include(c => c.Licensee)
        .Where(condition)
        .ToListAsync();
}