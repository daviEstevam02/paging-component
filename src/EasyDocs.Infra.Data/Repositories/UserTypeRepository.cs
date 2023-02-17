using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class UserTypeRepository : BaseRepository<UserType>, IUserTypeRepository
{
    public UserTypeRepository(EasyDocsContext context) : base(context)
    { }

    public override async Task<IEnumerable<UserType>> GetAll(Expression<Func<UserType, bool>> condition)
        => await _dbSet
        .Include(ut => ut.Company)
        .ThenInclude(c => c.Licensee)
        .Where(condition)
        .ToListAsync();

    public override async Task<UserType> GetOneWhere(Expression<Func<UserType, bool>> condition)
        => (await _dbSet
        .Include(ut => ut.Company)
        .ThenInclude(c => c.Licensee)
        .SingleOrDefaultAsync(condition))!;

    public async Task<bool> UserTypeExists(Guid userTypeId)
        => await _dbSet.SingleOrDefaultAsync(u => u.Id == userTypeId) is not null;
}