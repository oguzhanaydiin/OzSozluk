using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.Repositories;

public class EntryRepository : GenericRepository<Entry>, IEntryRepository
{
    public EntryRepository(OzSozlukContext dbContext) : base(dbContext)
    {
    }
}
