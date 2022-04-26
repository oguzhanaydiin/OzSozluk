using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OzSozlukContext dbContext) : base(dbContext)
        {
        }

        public Task TestMethod()
        {
            throw new NotImplementedException();
        }
    }
}
