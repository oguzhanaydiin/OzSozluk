using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
{
    public EntryCommentRepository(OzSozlukContext dbContext) : base(dbContext)
    {
    }
}
