using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.Login
{
    public class LoginDto
    {
        public string Apelido { get; set; }
        public string Senha { get; set; }


        public LoginDto() { }
        public LoginDto(UsuarioModel model)
        {
            Apelido = model.Apelido;
            Senha = model.Senha;
        }

    }
}
