using Domain.Entities;
using Domain.Enum;
using System.Text.Json.Serialization;

namespace Contracts.Requests;

public record class UpdatePositionRequest
{
    [JsonIgnore] public Guid Id { get; set; }
    public required string Title { get; set; }
    public decimal Salary { get; set; }
    public required string Responsibilities { get; set; }
}