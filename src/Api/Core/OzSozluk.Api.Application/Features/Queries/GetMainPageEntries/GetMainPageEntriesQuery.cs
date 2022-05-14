using OzSozluk.Common.Models.Page;
using OzSozluk.Common.Models.Queries;
using MediatR;

namespace OzSozluk.Api.Application.Features.Queries.GetMainPageEntries;
public class GetMainPageEntriesQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryDetailViewModel>>
{
    public GetMainPageEntriesQuery(Guid? userId, int page, int pageSize) : base(page, pageSize)
    {
        UserId = userId;
    }

    public Guid? UserId { get; set; }
}