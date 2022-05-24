using MediatR;
using Microsoft.EntityFrameworkCore;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common.Infrastructure.Extensions;
using OzSozluk.Common.Models.Page;
using OzSozluk.Common.Models.Queries;

namespace OzSozluk.Api.Application.Features.Queries.GetEntryComments;

public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQuery, PagedViewModel<GetEntryCommentViewModel>>
{
    private readonly IEntryCommentRepository _entryCommentRepository;

    public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository)
    {
        _entryCommentRepository = entryCommentRepository;
    }

    public async Task<PagedViewModel<GetEntryCommentViewModel>> Handle(GetEntryCommentsQuery request, CancellationToken cancellationToken)
    {
        var query = _entryCommentRepository.AsQueryable();

        query = query.Include(i => i.EntryCommentFavorites)
                     .Include(i => i.CreatedBy)
                     .Include(i => i.EntryCommentVotes)
                     .Where(i => i.EntryId == request.EntryId);

        var list = query.Select(i => new GetEntryCommentViewModel()
        {
            Id = i.Id,
            Content = i.Content,
            IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites.Any(j => j.CreatedById == request.UserId),
            FavoritedCount = i.EntryCommentFavorites.Count,
            CreatedDate = i.CreateDate,
            CreatedByUserName = i.CreatedBy.UserName,
            VoteType =
                request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreatedById == request.UserId)
                ? i.EntryCommentVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType
                : Common.ViewModels.VoteType.None
        });

        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}
