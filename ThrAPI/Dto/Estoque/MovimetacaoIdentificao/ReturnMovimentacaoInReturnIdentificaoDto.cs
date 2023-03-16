using ThrAPI.Dto.Estoque.LocaisEstocagem;
using ThrAPI.Dto.Login.Login;

namespace ThrAPI.Dto.Estoque.MovimetacaoIdentificao
{
    public class ReturnMovimentacaoInReturnIdentificaoDto
    {
        public Guid MovimentacaoId { get; set; }
        public UserDto UsuarioMovimentacao { get; set; }
        public DateTime DataHoraMovimentaco { get; set; }
        public LocalEstocagemResumidoDto LocalOrigem { get; set; }
        public LocalEstocagemResumidoDto LocalDestino { get; set; }
    }
}
