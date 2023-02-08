using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Transactions;
using System.Linq.Expressions;

namespace EasyDocs.Domain.Core.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    IUnitOfWork UnitOfWork { get; }

    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> condition);
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
    void Add(T entity);
    void Update(Guid id, T entity);
    void Delete(T entity);
}