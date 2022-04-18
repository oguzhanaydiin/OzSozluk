﻿using OzSozluk.Common.ViewModels;

namespace OzSozluk.Api.Domain.Models;

public class EntryVote : BaseEntity
{
    public Guid EntryId { get; set; }
    public VoteType voteType { get; set; }
    public Guid CreatedById { get; set; }


    public virtual Entry Entry { get; set; }
}

