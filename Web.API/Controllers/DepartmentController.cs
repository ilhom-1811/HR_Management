using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController(IBaseService<Department> departmentService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Department.Create)]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentsRequests request, CancellationToken token)
        {
            var department = mapper.Map<Department>(request);

            var response = await departmentService.CreateAsync(department, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Department.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var departmentExist = await departmentService.GetAsync(id, token);

            var response = mapper.Map<SingleDepartmentResponse>(departmentExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Department.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var departments = await departmentService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SingleDepartmentResponse>>(departments);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Department.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartmentRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Department department = await departmentService.GetAsync(id, token);

            department.Name = request.Name;
            department.Description = request.Description;

            await departmentService.UpdateAsync(department, token);

            var response = mapper.Map<SingleDepartmentResponse>(department);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Department.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await departmentService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Department with ID {id} not found.");
        }
    }
}