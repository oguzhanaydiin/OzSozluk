using MediatR;
using OzSozluk.Common;
using OzSozluk.Common.Events.EntryComment;
using OzSozluk.Common.Infrastructure;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Api.Application.Features.Commands.EntryComment.CreateVote;
public class CreateEntryCommentVoteCommandHandler :
    IRequestHandler<CreateEntryCommentVoteCommand, bool>
{
    public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryCommentVoteQueueName,
            obj: new CreateEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                VoteType = request.VoteType,
                CreatedBy = request.CreatedBy
            });

        return await Task.FromResult(true);
    }
}