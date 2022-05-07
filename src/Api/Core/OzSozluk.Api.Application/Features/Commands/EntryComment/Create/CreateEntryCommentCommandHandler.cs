using AutoMapper;
using MediatR;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Api.Application.Features.Commands.EntryComment.Create;

public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
{
    private readonly IEntryCommentRepository entryCommentRepository;
    private readonly IMapper mapper;

    public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
    {
        this.entryCommentRepository = entryCommentRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
    {
        var dbEntryComment = mapper.Map<Domain.Models.EntryComment>(request);

        await entryCommentRepository.AddAsync(dbEntryComment);

        return dbEntryComment.Id;
    }
}