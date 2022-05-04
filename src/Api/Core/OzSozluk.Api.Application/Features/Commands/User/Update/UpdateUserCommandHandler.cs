using AutoMapper;
using MediatR;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common;
using OzSozluk.Common.Events.User;
using OzSozluk.Common.Infrastructure;
using OzSozluk.Common.Infrastructure.Exceptions;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;
    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetByIdAsync(request.Id);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("User not found!");
        }

        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;

        mapper.Map(request, dbUser); //source -> destination, diger mapten farkı burada yeni obje olusturmadan sadece aktaracak


        var rows = await userRepository.UpdateAsync(dbUser);

        //check if email changed
        if (emailChanged && rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.EmailAddress
            };

            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                                exchangeType: SozlukConstants.DefaultExchangeType,
                                                queueName: SozlukConstants.UserEmailChangedQueueName,
                                                obj: @event);

            dbUser.EmailConfirmed = false;
            await userRepository.UpdateAsync(dbUser);
        }

        return dbUser.Id;
    }
}
