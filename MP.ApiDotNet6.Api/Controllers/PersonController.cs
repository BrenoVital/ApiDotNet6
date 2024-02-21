using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTO;
using MP.ApiDotNet6.Application.Services.Interface;

namespace MP.ApiDotNet6.Api.Controllers
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.Create(personDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _personService.GetAll();
            if (result.Success)
            {
                result.Message = "Pessoas encontradas";
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _personService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _personService.Delete(id);
            if (result.Success)
            {
                var message = $"Pessoa {result.Data.Name} excluída com sucesso";
                return Ok(message);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.Update(personDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }   
    }
}
