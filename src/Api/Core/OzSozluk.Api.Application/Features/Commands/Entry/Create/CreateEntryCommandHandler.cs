using AutoMapper;
using MediatR;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Api.Application.Features.Commands.Entry.Create;

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
{
    private readonly IEntryRepository entryRepository;
    private readonly IMapper mapper;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        this.entryRepository = entryRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = mapper.Map<Domain.Models.Entry>(request);

        await entryRepository.AddAsync(dbEntry);

        return dbEntry.Id;
    }
}
