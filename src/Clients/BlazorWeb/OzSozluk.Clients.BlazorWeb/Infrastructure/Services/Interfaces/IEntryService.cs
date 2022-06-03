using OzSozluk.Common.Models.Page;
using OzSozluk.Common.Models.Queries;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Clients.BlazorWeb.Infrastructure.Services.Interfaces;

public interface IEntryService
{
    Task<List<GetEntriesViewModel>> GetEntires();

    Task<GetEntryDetailViewModel> GetEntryDetail(Guid entryId);

    Task<PagedViewModel<GetEntryDetailViewModel>> GetMainPageEntries(int page, int pageSize);

    Task<PagedViewModel<GetEntryDetailViewModel>> GetProfilePageEntries(int page, int pageSize, string userName = null);

    Task<PagedViewModel<GetEntryCommentViewModel>> GetEntryComments(Guid entryId, int page, int pageSize);


    Task<Guid> CreateEntry(CreateEntryCommand command);

    Task<Guid> CreateEntryComment(CreateEntryCommentCommand command);

    Task<List<SearchEntryViewModel>> SearchBySubject(string searchText);

}
