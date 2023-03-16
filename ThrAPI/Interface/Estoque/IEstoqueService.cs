using ThrAPI.Dto.Estoque.Estoque;
using ThrAPI.Models.Estoque;
using System;

namespace ThrAPI.Interface.Estoque
{
    public interface IEstoqueService
    {
        Task<List<ProdutoEstoqueDto>>  ObterProdutosEstoque();
        Task<NovoProdutoDto> CadastrarProduto(CadastroProdutoDto dto);
        Task<EstoqueModel> DeletarProduto(Guid id);
        Task<EstoqueModel> AlterarProduto(ProdutoEstoqueDto dto);
        Task<ProdutoEstoqueDto> BuscarPorCodigo(string codigo);
        Task<ProdutoEstoqueDto> UpdateEstoque(Guid codigo, decimal quantidadeMovimentada);
        Task<ProdutoMovimentacaoDto> BuscarMovimentacao(string codigo);


        bool ValidarEstoque(decimal estoqueMinimo, decimal estoqueMaximo, decimal estoqueSeguranca);

        void DeletarTodosProdutos();
    }
}
