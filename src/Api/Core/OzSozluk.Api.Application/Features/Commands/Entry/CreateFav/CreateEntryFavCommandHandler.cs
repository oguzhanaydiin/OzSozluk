using MediatR;
using OzSozluk.Common;
using OzSozluk.Common.Events.Entry;
using OzSozluk.Common.Infrastructure;

namespace OzSozluk.Api.Application.Features.Commands.Entry.CreateFav;

public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
{

    public Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryFavQueueName,
            obj: new CreateEntryFavEvent()
            {
                EntryId = request.EntryId.Value,
                CreatedBy = request.UserId.Value
            });

        return Task.FromResult(true);
    }
}