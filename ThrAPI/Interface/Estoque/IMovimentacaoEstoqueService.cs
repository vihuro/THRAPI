using ThrAPI.Dto.Estoque.Movimentacao;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Interface.Estoque
{
    public interface IMovimentacaoEstoqueService
    {
        Task<List<MovimentacoesDto>> FindAll();
        Task<RetornoMovimentacaoDto> Insert(NovaMovimentacaoDto dto);
        Task<List<MovimentacoesDto>> BuscarPorCodigo(string codigo);
        Task<RetornoMovimentacaoDto> Movimentacao(MovimentaoEstoqueModel estoque, Guid id);
    }
}
