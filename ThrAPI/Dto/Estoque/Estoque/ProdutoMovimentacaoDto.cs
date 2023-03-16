using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.Estoque
{
    public class ProdutoMovimentacaoDto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public ProdutoMovimentacaoDto() { }
        public ProdutoMovimentacaoDto(EstoqueModel model)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.Unidade = Unidade;
        }
    }
}
