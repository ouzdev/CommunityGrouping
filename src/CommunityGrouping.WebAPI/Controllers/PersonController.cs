using CommunityGrouping.Business.Filters;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Entities.QueryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CommunityGrouping.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginationAsync([FromQuery] PersonFilter personFilter)
        {

            var route = Request.Path.Value;

            PersonFilter filter = new(personFilter.PageNumber, personFilter.PageSize, personFilter.SortOrder, personFilter.FirstName, personFilter.LastName);

            var result = await _personService.GetPaginationAsync(filter, route);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            var result = await _personService.InsertAsync(personDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("BulkInsert")]
        public async Task<IActionResult> InsertBulkPerson([FromForm] IFormFile file)
        {
            var result = await _personService.InsertBulkPerson(file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AddPersonToGroup")]
        public async Task<IActionResult> AddPersonToCommunityGroup([FromQuery] AddPersonToGroupQuery addPersonToGroupDto)
        {
            var result = await _personService.AddPersonToCommunityGroup(addPersonToGroupDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("DeletePersonToGroup")]
        public async Task<IActionResult> DeletePersonToCommunityGroup([FromQuery] int id)
        {
            var result = await _personService.DeletePersonToCommunityGroup(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonDto personDto)
        {
            var result = await _personService.UpdateAsync(id, personDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }


}
