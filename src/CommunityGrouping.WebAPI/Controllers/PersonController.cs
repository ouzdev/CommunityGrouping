using CommunityGrouping.Business.Filters;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CommunityGrouping.API.Controllers
{
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
        public async Task<IActionResult> GetPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] PersonFilter filter)
        {

            var route = Request.Path.Value;
            PaginationFilter pagintation = new PaginationFilter(pageNumber, pageSize);
            var result = await _personService.GetPaginationAsync(pagintation, new (), route);

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

        [Authorize]

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        //{
        //    var result = await _personService.InsertAsync(personDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [Authorize]

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
        [Authorize]

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
