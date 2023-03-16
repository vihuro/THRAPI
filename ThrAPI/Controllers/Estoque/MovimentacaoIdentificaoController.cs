using Microsoft.AspNetCore.Mvc;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.Movimentacao;
using ThrAPI.Dto.Estoque.MovimetacaoIdentificao;
using ThrAPI.Interface.Estoque;

namespace ThrAPI.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque/identificao/movimentacao")]
    public class MovimentacaoIdentificaoController : ControllerBase
    {
        private readonly IMovimentacaoIdentificaoService _service;
        public MovimentacaoIdentificaoController(IMovimentacaoIdentificaoService service)
        {
            this._service = service;
        }
        [HttpGet]
        public void SelectAll()
        {

        }
        [HttpGet("{id}")]
        public ActionResult<RetornoMovimentacaoDto> SelectId(Guid id)
        {
            try
            {
                return Ok(_service.SelectFromId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<ReturnMovimentacaoInReturnIdentificaoDto> Insert(InsertMovimentacaoIdentificaoDto dto)
        {
            try
            {
                return Ok(_service.InsertMovimentacao(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
