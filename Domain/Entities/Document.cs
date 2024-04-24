using Domain.Enum;

namespace Domain.Entities;

public class Document : BaseEntity
{
    public required string Type { get; set; }
    public DateTime Date { get; set; }
    public DocumentStatus Status { get; set; }
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}