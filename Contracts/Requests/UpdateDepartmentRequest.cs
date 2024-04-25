using Domain.Entities;
using Domain.Enum;
using System.Text.Json.Serialization;

namespace Contracts.Requests;

public record class UpdateDepartmentRequest
{
    [JsonIgnore] public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}