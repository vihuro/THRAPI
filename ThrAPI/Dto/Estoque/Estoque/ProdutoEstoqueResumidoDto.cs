namespace ThrAPI.Dto.Estoque.Estoque
{
    public class ProdutoEstoqueResumidoDto
    {
        public Guid ProdutoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set;}
        public string Unidade { get; set; }
    }
}
