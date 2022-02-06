using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController : ControllerBase
    {

        private readonly IFormService _formsService;

        public FormsController(IFormService formsService)
        {
            _formsService = formsService;
        }

        /// <summary>
        /// Get all the Forms on DB
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet(Name = "GetForms")]
        public async Task<IEnumerable<Form>> GetForms()
        {
            return (await _formsService.GetAllAsync());
        }

        /// <summary>
        /// Create a new form
        /// </summary>
        /// <param name="FormDto">Request's payload</param>
        /// <returns></returns>
        /// <response code="201">Formulário criado com sucesso.</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] FormDto dto)
        {
            if (ModelState.IsValid)
            {
                await _formsService.CreateAsync(dto);
                return Ok(new ActionResponse("Created", "201", "Formulário criado com sucesso."));
            }

            return Ok(new ActionResponse("BadRequest", "400", "Dados inválidos."));
        }

        /// <summary>
        /// Change the readed prop of a Form
        /// </summary>
        /// <param name="id">Request's payload</param>
        /// <returns></returns>
        /// <response code="200">Formulário atualizado com sucesso.</response>
        [HttpPut("mark-as-readed/{*id}")]
        public async Task<IActionResult> MarkAsReaded(Guid id)
        {
            var form = await _formsService.GetById(id);

            if (form is null)
            {
                return Ok(new ActionResponse("No Content", "204", $"O formulário com o id {id} não foi encontrado."));
            }

            await _formsService.MarkAsReaded(form);
            return Ok(new ActionResponse("Ok", "200", "Dados atualizados."));
        }

        /// <summary>
        /// Change the answered prop of a Form
        /// </summary>
        /// <param name="id">Request's payload</param>
        /// <returns></returns>
        /// <response code="200">Formulário atualizado com sucesso.</response>
        [HttpPut("mark-as-answered/{*id}")]
        public async Task<IActionResult> MarkAsAnswered(Guid id)
        {
            var form = await _formsService.GetById(id);

            if (form is null)
            {
                return Ok(new ActionResponse("No Content", "204", "O formulário não foi encontrado."));
            }

            await _formsService.MarkAsAnswered(form);
            return Ok(new ActionResponse("Ok", "200", "Dados atualizados."));
        }

        /// <summary>
        /// Delete a Form
        /// </summary>
        /// <param name="id">Request's payload</param>
        /// <returns></returns>
        /// <response code="200">Formulário eliminado com sucesso.</response>
        [HttpDelete("delete/{*id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var form = await _formsService.GetById(id);

            if (form is null)
            {
                return Ok(new ActionResponse("No Content", "204", "O formulário não foi encontrado."));
            }

            await _formsService.Delete(form);
            return Ok(new ActionResponse("Ok", "200", "O formulário foi apagado com sucesso."));
        }
    }
}