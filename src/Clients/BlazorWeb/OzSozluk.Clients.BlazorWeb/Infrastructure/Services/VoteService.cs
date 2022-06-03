using OzSozluk.Clients.BlazorWeb.Infrastructure.Services.Interfaces;
using OzSozluk.Common.ViewModels;

namespace OzSozluk.Clients.BlazorWeb.Infrastructure.Services;

public class VoteService : IVoteService
{
    private readonly HttpClient client;
    public VoteService(HttpClient client)
    {
        this.client = client;
    }

    public async Task DeleteEntryVote(Guid entryId)
    {
        var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("DeleteEntryVote error");
        }
    }
    public async Task DeleteEntryCommentVote(Guid entryCommentId)
    {
        var response = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("DeleteEntryCommentVote error");
        }
    }
    public async Task CreateEntryUpVote(Guid entryId)
    {
        await CreateEntryVote(entryId, VoteType.UpVote);
    }
    public async Task CreateEntryDownVote(Guid entryId)
    {
        await CreateEntryVote(entryId, VoteType.DownVote);
    }
    public async Task CreateEntryCommentUpVote(Guid entryCommentId)
    {
        await CreateEntryCommentVote(entryCommentId, VoteType.UpVote);
    }
    public async Task CreateEntryCommentDownVote(Guid entryCommentId)
    {
        await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);
    }

    #region private methods
    private async Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
    {
        //entryid urlden alinacak fakat votetype default query string 
        var result = await client.PostAsync($"/api/Vote/entry/{entryId}?voteType={voteType}", null);

        return result;
    }

    private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
    {
        //entryid urlden alinacak fakat votetype default query string 
        var result = await client.PostAsync($"/api/Vote/entrycomment/{entryCommentId}?voteType={voteType}", null);

        return result;
    }

    #endregion

}
