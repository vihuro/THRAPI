using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.Movimentacao
{
    public class MovimentacoesDto
    {
        public Guid Id { get; set; }
        public string CodigoMaterial { get; set; }
        public string DescricaoMaterial { get; set; }
        public string Unidade { get; set; }
        public string TipoMovimentacao { get; set; }
        public decimal QuantidadeMovimentada { get; set; }
        public DateTime DataHoraMovimentacao { get; set; }
        public string UsuarioMovimentacao { get; set; }
        public string StatusMovimentacao { get; set; }

        public MovimentacoesDto() { }

        public MovimentacoesDto(MovimentaoEstoqueModel model)
        {
            Id = model.Id;
            CodigoMaterial = model.Estoque.Codigo;
            DescricaoMaterial = model.Estoque.Descricao;
            Unidade = model.Estoque.Unidade;
            TipoMovimentacao = model.TipoMovimentacao;
            QuantidadeMovimentada = model.QuantidadeMovimentada;
            DataHoraMovimentacao = model.DataHoraMovimentacao;
            UsuarioMovimentacao = model.UsuarioMovimentacaoId.ToString();
            StatusMovimentacao = model.StatusMovimentacao;
        }
    }
}
