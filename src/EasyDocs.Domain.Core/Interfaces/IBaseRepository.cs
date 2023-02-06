using EasyDocs.Domain.Core.Entities;

namespace EasyDocs.Domain.Core.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    Task Add(T entity);
    Task Update(T entity);
}