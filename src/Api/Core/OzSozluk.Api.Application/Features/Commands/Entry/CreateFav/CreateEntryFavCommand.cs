﻿using MediatR;

public class CreateEntryFavCommand : IRequest<bool>
{
    public Guid? EntryId { get; set; }

    public Guid? UserId { get; set; }

    public CreateEntryFavCommand(Guid? entryId, Guid? userId)
    {
        EntryId = entryId;
        UserId = userId;
    }
}
