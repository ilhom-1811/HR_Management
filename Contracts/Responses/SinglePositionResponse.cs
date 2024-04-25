using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record class SinglePositionResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public decimal Salary { get; init; }
    public string Responsibilities { get; init; }

}