using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces;

public interface ILicenseeRepository : IBaseRepository<Licensee>
{
    Task<bool> LicenseeExists(Guid id);
}