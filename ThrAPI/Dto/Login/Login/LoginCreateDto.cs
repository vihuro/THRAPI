using ThrAPI.Dto.Login.Claims;
using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.Login
{
    public class LoginCreateDto
    {
        public string NomeUsuario { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public List<ClaimValueCadastroUsuario> Claims { get; set; }

        public LoginCreateDto()
        {

        }
        public LoginCreateDto(UsuarioModel model)
        {
            NomeUsuario = model.NomeUsuario;
            Apelido = model.Apelido;
        }
    }
}
