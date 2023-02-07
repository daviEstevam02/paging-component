using EasyDocs.Domain.Core.Entities;
using System.Linq.Expressions;

namespace EasyDocs.Domain.Core.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
    Task Add(T entity);
    void Update(Guid id, T entity);
    void Delete(T entity);
}