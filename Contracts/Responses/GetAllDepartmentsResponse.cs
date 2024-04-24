namespace Contracts.Responses;

public record class GetAllDepartmentsResponse
{
    public IEnumerable<SingleDepartmentResponse> Items { get; init; } = Enumerable.Empty<SingleDepartmentResponse>();
}