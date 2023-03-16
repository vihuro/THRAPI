using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using ThrAPI.Dto.Estoque.LocaisEstocagem;
using ThrAPI.Interface.Estoque;

namespace ThrAPI.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque/locaisEstocagem")]
    public class LocaisEstocagemController : ControllerBase
    {
        private readonly ILocalEstocagemService service;
        public LocaisEstocagemController(ILocalEstocagemService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult> TodosLocais()
        {
            try
            { 
                return Ok(service.TodosLocais());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult Insert([FromBody]InserirLocalDto dto)
        {
            try
            {
                return Created("",service.InserirLocal(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                return Ok(service.DeleteTodosLocais());

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(AtualizarLocalDto dto)
        {
            try
            {
                return Ok(service.AtualizarLocal(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
