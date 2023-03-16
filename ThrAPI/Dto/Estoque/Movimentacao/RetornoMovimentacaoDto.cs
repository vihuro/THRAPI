using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.Movimentacao
{
    public class RetornoMovimentacaoDto
    {
        public Guid Id { get; set; }
        public string CodigoMaterial { get; set; }
        public string DescricaoMaterial { get; set; }
        public string Unidade { get; set; }
        public decimal QuantidadeMovimentada { get; set; }
        public string TipoMovimentacao { get; set; }
        public DateTime DataHoraMovimentacao { get; set; }
        public string UsuarioMovimentacao { get; set; }
        public decimal QuantidadeDisponivel { get; set; }

        public RetornoMovimentacaoDto() { }
        public RetornoMovimentacaoDto(MovimentaoEstoqueModel model) 
        {
            Id = model.Id;
            CodigoMaterial = model.Estoque.Codigo;
            DescricaoMaterial = model.Estoque.Descricao;
            Unidade = model.Estoque.Unidade;
            QuantidadeDisponivel = model.Estoque.QuantidadeEstoque;
            TipoMovimentacao = model.TipoMovimentacao;
            DataHoraMovimentacao = model.DataHoraMovimentacao;
            UsuarioMovimentacao = model.UsuarioMovimentacao.NomeUsuario;
            QuantidadeMovimentada = model.QuantidadeMovimentada;
        }
    }
}
