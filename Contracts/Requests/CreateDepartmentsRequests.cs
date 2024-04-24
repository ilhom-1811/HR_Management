using Domain.Entities;
using Domain.Enum;

namespace Contracts.Requests;

public record class CreateDepartmentsRequests
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}