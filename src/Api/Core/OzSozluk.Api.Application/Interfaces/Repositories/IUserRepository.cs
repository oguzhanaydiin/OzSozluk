using OzSozluk.Api.Domain.Models;

namespace OzSozluk.Api.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task TestMethod();
}
