using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.Movimentacao
{
    public class NovaMovimentacaoDto
    {
        
        public string CodigoMaterial { get; set; }
        public decimal QuantidadeMovimentada { get; set; }
        public string TipoMovimentacao { get; set; }
        public Guid UsuarioMovimentacao { get; set; }

        public NovaMovimentacaoDto() { }
        public NovaMovimentacaoDto(MovimentaoEstoqueModel model)
        {
            QuantidadeMovimentada = model.QuantidadeMovimentada;
            TipoMovimentacao = model.TipoMovimentacao;
            UsuarioMovimentacao = model.UsuarioMovimentacaoId;
        }
    }
}
