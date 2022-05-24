﻿namespace OzSozluk.Common.Models.Queries;

public class GetEntryCommentViewModel : BaseFooterRateFavoritedViewModel
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedByUserName { get; set; }
}
