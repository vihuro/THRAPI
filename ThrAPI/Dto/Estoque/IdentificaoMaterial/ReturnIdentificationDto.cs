using ThrAPI.Dto.Estoque.Estoque;
using ThrAPI.Dto.Estoque.LocaisEstocagem;
using ThrAPI.Dto.Login.Login;

namespace ThrAPI.Dto.Estoque.IdentificaoMaterial
{
    public class ReturnIdentificationDto
    {
        public int IdentificacaoId { get; set; }
        public ProdutoEstoqueResumidoDto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PesoPalete { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        public string Lote { get; set; }
        public string IF { get; set; }
        public decimal Densidade { get; set; }
        public UserDto UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public UserDto UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public LocalEstocagemResumidoDto LocalEstocagem { get; set; }
    }
}
