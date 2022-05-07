using MediatR;
using OzSozluk.Common.ViewModels;

namespace OzSozluk.Common.Models.RequestModels;
public class CreateEntryVoteCommand : IRequest<bool>
{
    public Guid EntryId { get; set; }

    public VoteType VoteType { get; set; }

    public Guid CreatedBy { get; set; }
}