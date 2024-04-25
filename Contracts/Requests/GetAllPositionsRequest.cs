using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllPositionsRequest
{
    public IEnumerable<Position> Items { get; init; } = Enumerable.Empty<Position>();

}