namespace ThrAPI.Dto.Estoque.MovimetacaoIdentificao
{
    public class InsertMovimentacaoIdentificaoDto
    {
        public Guid IdIdentificao { get; set; }
        public decimal Quantidade { get; set; }
        public Guid UsuarioMovimentacaoId { get; set; }
        public Guid LocalEstocagelId { get; set; }
    }
}
