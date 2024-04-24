using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Domain.Entities;

public class Employee : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }
    public required string ContactInfo { get; set; }
    public DateTime HireDate { get; set; }
    public Guid PositionId { get; set; }
    public Guid DepartmentId { get; set; }
    public EmployeeStatus Status { get; set; }
    
    public Position? Position { get; set; }
    public Department? Department { get; set; }
    public ICollection<Document>? Documents { get; set; }
}