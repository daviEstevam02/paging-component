namespace EasyDocs.Domain.Core.Transactions;

public interface IUnitOfWork
{
    Task<bool> Commit();
}