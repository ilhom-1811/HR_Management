namespace Contracts.Requests;

public record class CreatePositionsRequests
{
    public required string Title { get; init; }
    public decimal Salary { get; init; }
    public required string Responsibilities { get; init; }
}
