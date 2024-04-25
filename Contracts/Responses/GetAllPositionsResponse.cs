namespace Contracts.Responses;

public record class GetAllPositionsResponse
{
    public IEnumerable<SinglePositionResponse> Items { get; init; } = Enumerable.Empty<SinglePositionResponse>();
}