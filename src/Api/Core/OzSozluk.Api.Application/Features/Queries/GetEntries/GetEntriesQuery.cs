using OzSozluk.Common.Models.Queries;
using MediatR;

namespace OzSozluk.Api.Application.Features.Queries.GetEntries;
public class GetEntriesQuery : IRequest<List<GetEntriesViewModel>>
{
    public bool TodaysEntries { get; set; }

    public int Count { get; set; } = 100;
}