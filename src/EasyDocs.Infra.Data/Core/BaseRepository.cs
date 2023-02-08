﻿using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Core.Transactions;
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

    public IUnitOfWork UnitOfWork => _context;

    public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> condition)
        => await _dbSet.Where(condition).ToListAsync();

    public virtual async Task<T> GetOneWhere(Expression<Func<T, bool>> condition)
        => (await _dbSet.SingleOrDefaultAsync(condition))!;

    public virtual void Add(T entity)
        => _dbSet.Add(entity);

    public virtual void Update(Guid id, T entity)
        => _dbSet.Update(entity);

    public virtual void Delete(T entity)
        => _dbSet.Remove(entity);
}