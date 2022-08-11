using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityGrouping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;
        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _occupationService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);

            }

            return NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _occupationService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return NotFound(result);
        }
        [Authorize]

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OccupationDto occupationDto)
        {
            var result = await _occupationService.InsertAsync(occupationDto);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
        [Authorize]

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OccupationDto occupationDto)
        {
            var result = await _occupationService.UpdateAsync(id,occupationDto);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
        [Authorize]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _occupationService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
    }
}
