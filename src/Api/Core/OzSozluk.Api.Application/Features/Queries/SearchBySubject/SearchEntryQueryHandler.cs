using MediatR;
using Microsoft.EntityFrameworkCore;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common.Models.Queries;

namespace OzSozluk.Api.Application.Features.Queries.SearchBySubject;

public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
{
    private readonly IEntryRepository entryRepository;

    public SearchEntryQueryHandler(IEntryRepository entryRepository)
    {
        this.entryRepository = entryRepository;
    }

    public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
    {
        var result = entryRepository
            .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
            .Select(i => new SearchEntryViewModel()
            {
                Id = i.Id,
                Subject = i.Subject,
            });

        return await result.ToListAsync(cancellationToken);
    }
}
