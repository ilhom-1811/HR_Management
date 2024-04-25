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
    public class PositionController(IBaseService<Position> positionService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Position.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePositionsRequests request, CancellationToken token)
        {
            var position = mapper.Map<Position>(request);

            var response = await positionService.CreateAsync(position, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Position.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var positionExist = await positionService.GetAsync(id, token);

            var response = mapper.Map<SinglePositionResponse>(positionExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Position.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var positions = await positionService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SinglePositionResponse>>(positions);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Position.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePositionRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Position position = await positionService.GetAsync(id, token);

            position.Title = request.Title;
            position.Salary = request.Salary;
            position.Responsibilities = request.Responsibilities;

            await positionService.UpdateAsync(position, token);

            var response = mapper.Map<SinglePositionResponse>(position);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Position.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await positionService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Position with ID {id} not found.");
        }
    }
}