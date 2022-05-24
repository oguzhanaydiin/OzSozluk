using MediatR;
using OzSozluk.Common.Models.Page;
using OzSozluk.Common.Models.Queries;

namespace OzSozluk.Api.Application.Features.Queries.GetEntryComments;

public class GetEntryCommentsQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryCommentViewModel>>
{
    public GetEntryCommentsQuery(Guid entryId, Guid? userId, int page, int pageSize) : base(page, pageSize)
    {
        EntryId = entryId;
        UserId = userId;
    }

    public Guid EntryId { get; set; }
    public Guid? UserId { get; set; }
}
