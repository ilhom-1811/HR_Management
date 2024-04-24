namespace Domain.Entities;

public class Position : BaseEntity
{
    public required string Title { get; set; }
    public decimal Salary { get; set; }
    public required string Responsibilities { get; set; }
}