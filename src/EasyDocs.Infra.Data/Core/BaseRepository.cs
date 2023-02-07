using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyDocs.Infra.Data.Core;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly EasyDocsContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(EasyDocsContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
        => await _dbSet.ToListAsync();

    public async Task<T> GetOneWhere(Expression<Func<T, bool>> condition)
        => (await _dbSet.SingleOrDefaultAsync(condition))!;

    public async Task Add(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(Guid id, T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
        => _dbSet.Remove(entity);
}