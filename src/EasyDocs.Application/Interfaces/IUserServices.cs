using EasyDocs.Application.Core;

namespace EasyDocs.Application.Interfaces;

public interface IUserServices
{
    Task<ServiceResponse> Login(string email, string password);
}