using Microsoft.AspNetCore.Mvc;
using ThrAPI.Dto.Estoque.Movimentacao;
using ThrApi.Service.CustonException;
using ThrAPI.Interface.Estoque;

namespace ThrAPI.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque/movimentacao")]
    public class MovimentacaoEstoqueController : ControllerBase
    {
        private readonly IMovimentacaoEstoqueService movimentacoService;
        public MovimentacaoEstoqueController(IMovimentacaoEstoqueService movimentacoService)
        {
            this.movimentacoService = movimentacoService;
        }
        [HttpGet("findAll")]
        public ActionResult<MovimentacoesDto> Buscar()
        {
            try
            {
                return Ok(movimentacoService.FindAll());

            }
            catch (ExceptionService ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{codigo}")]
        public ActionResult<List<MovimentacoesDto>> BuscarPorCodigo(string codigo)
        {
            try
            {
                return Ok(movimentacoService.BuscarPorCodigo(codigo));
            }
            catch (ExceptionService ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public ActionResult<MovimentacoesDto> Insert([FromBody] NovaMovimentacaoDto dto)
        {
            try
            {
                return Ok(movimentacoService.Insert(dto));
            }
            catch (ExceptionService ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
