using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EasyDocsContext context)
        : base(context)
    { }

    public async override Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> condition)
        => await _dbSet
        .Include(u => u.Company)
        .ThenInclude(c => c.Licensee)
        .Where(condition)
        .ToListAsync();

    public async override Task<User> GetOneWhere(Expression<Func<User, bool>> condition)
       => (await _dbSet
       .Include(u => u.Company)
       .ThenInclude(c => c.Licensee)
       .SingleOrDefaultAsync(condition))!;

    public async Task<bool> UserExists(Guid id)
        => await GetOneWhere(user => user.Id == id) is not null;
}