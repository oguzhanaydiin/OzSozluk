using MediatR;
using OzSozluk.Common.Models.Page;
using OzSozluk.Common.Models.Queries;

namespace OzSozluk.Api.Application.Features.Queries.GetUserEntries
{
    public class GetUserEntriesQuery : BasePagedQuery, IRequest<PagedViewModel<GetUserEntriesDetailViewModel>>
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public GetUserEntriesQuery(Guid? userId, string userName = null, int page = 1, int pagesize = 10) : base(page, pagesize)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}