using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class DepartmentMapProfile : Profile
{
    public DepartmentMapProfile()
    {
        CreateMap<CreateDepartmentsRequests, Department>();

        CreateMap<Department, CreateDepartmentsRequests>();

        CreateMap<GetAllDepartmentsRequest, GetAllDepartmentsResponse>();

        CreateMap<UpdateDepartmentRequest, Department>();
    }
}