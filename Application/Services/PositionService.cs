using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class PositionService(IBaseRepository<Position> positionRepository) : IBaseService<Position>
{
    public async Task<Position> CreateAsync(Position position, CancellationToken token = default)
    {
        return await positionRepository.CreateAsync(position, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var position = await positionRepository.GetAsync(id, token);

        if (position == null)
            return false;

        return await positionRepository.DeleteAsync(position, token);
    }

    public async Task<IEnumerable<Position>> GetAllAsync(CancellationToken token = default)
    {
        return await positionRepository.GetAllAsync(token);
    }

    public async Task<Position> GetAsync(Guid id, CancellationToken token = default)
    {
        return await positionRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Position position, CancellationToken token = default)
    {
        var positionExist = await positionRepository.GetAsync(position.Id, token);

        if (positionExist == null)
        {
            return false;
        }

        return await positionRepository.UpdateAsync(position, token);
    }
}