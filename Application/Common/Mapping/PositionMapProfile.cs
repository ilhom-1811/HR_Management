using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class PositionMapProfile : Profile
{
    public PositionMapProfile()
    {
        CreateMap<CreatePositionsRequests, Position>();

        CreateMap<Position, CreatePositionsRequests>();

        CreateMap<SinglePositionResponse, Position>();

        CreateMap<Position, SinglePositionResponse>();

        CreateMap<CreatePositionsRequests, GetAllPositionsResponse>();

        CreateMap<UpdatePositionRequest, Position>();
    }
}