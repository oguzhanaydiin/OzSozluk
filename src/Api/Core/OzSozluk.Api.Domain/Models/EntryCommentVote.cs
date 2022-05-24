using OzSozluk.Common.ViewModels;

namespace OzSozluk.Api.Domain.Models;

public class EntryCommentVote : BaseEntity
{
    public Guid EntryCommentId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid CreatedById { get; set; }


    public virtual EntryComment EntryComment { get; set; }
}

