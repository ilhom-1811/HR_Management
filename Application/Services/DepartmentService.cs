using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class DepartmentService(IBaseRepository<Department> departmentRepository) : IBaseService<Department>
{
    public async Task<Department> CreateAsync(Department department, CancellationToken token = default)
    {
        return await departmentRepository.CreateAsync(department, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var department = await departmentRepository.GetAsync(id, token);

        if (department == null)
            return false;

        return await departmentRepository.DeleteAsync(department, token);
    }

    public async Task<IEnumerable<Department>> GetAllAsync(CancellationToken token = default)
    {
        return await departmentRepository.GetAllAsync(token);
    }

    public async Task<Department> GetAsync(Guid id, CancellationToken token = default)
    {
        return await departmentRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Department department, CancellationToken token = default)
    {
        var departmentExist = await departmentRepository.GetAsync(department.Id, token);

        if (departmentExist == null)
        {
            return false;
        }

        return await departmentRepository.UpdateAsync(department, token);
    }
}