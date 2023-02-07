using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<bool> CompanyExists(Guid id);
}