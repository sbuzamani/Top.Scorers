using Microsoft.AspNetCore.Mvc;
using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Models;

namespace Top.Scorers.Api.Controllers
{
    [ApiController]
    [Route("top-scorers/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        private readonly ILogger<PersonController> _logger;
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet("top")]
        public async Task<ActionResult<IEnumerable<Person>>> GetTop()
        {
            var result = _personService.GetTop();
            if (result == null) {
                return NoContent();
            }
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var result = _personService.Get(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SavePerson(Person  person)
        {
            var result = _personService.Save(person);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
