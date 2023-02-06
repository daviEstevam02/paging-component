using EasyDocs.Domain.Core.Entities;
using System.Linq.Expressions;

namespace EasyDocs.Domain.Core.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
}