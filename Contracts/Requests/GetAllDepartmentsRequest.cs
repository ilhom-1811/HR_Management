using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllDepartmentsRequest
{
    public IEnumerable<Department> Items { get; init; } = Enumerable.Empty<Department>();

}