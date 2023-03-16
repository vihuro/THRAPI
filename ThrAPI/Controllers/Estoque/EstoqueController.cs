using Microsoft.AspNetCore.Mvc;
using ThrApi.Service.CustonException;
using ThrAPI.Dto.Estoque.Estoque;
using ThrAPI.Interface.Estoque;

namespace ThrAPI.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService estoqueService;
        public EstoqueController(IEstoqueService estoqueService)
        {
            this.estoqueService = estoqueService;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodosProdutos()
        {
            try
            {
                return Ok(await estoqueService.ObterProdutosEstoque());
            }
            catch (Exception ex)
            {

                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> BuscarPorCodigo(string codigo)
        {
            try
            {
                return Ok(await estoqueService.BuscarPorCodigo(codigo));
            }
            catch (ExceptionService ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarNovoProduto([FromBody] CadastroProdutoDto dto)
        {
            try
            {
                var cadatro = await estoqueService.CadastrarProduto(dto);
                return Ok(cadatro);
            }
            catch (ExceptionService ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarTodosProdutos()
        {
            try
            {
                estoqueService.DeletarTodosProdutos();

                return Ok();
            }
            catch (ExceptionService ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
