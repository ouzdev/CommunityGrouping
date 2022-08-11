using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityGrouping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityGroupController : ControllerBase
    {

        private readonly ICommunityGroupService _communityGroupService;
        public CommunityGroupController(ICommunityGroupService communityGroupService)
        {
            _communityGroupService = communityGroupService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _communityGroupService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);

            }

            return NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _communityGroupService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommunityGroupDto communityGroupDto)
        {
            var result = await _communityGroupService.InsertAsync(communityGroupDto);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommunityGroupDto communityGroupDto)
        {
            var result = await _communityGroupService.UpdateAsync(id, communityGroupDto);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _communityGroupService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);            
        }
    }
}
