using ThrAPI.Dto.Login.Claims;
using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.Login
{
    public class LoginUserDto
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Apelido { get; set; }
        public List<ClaimsOfUserDto> Claims { get; set; }

        public LoginUserDto(UsuarioModel model,List<ClaimsOfUserDto> claims)
        {
           Id = model.Id;
           NomeUsuario = model.NomeUsuario;
           Apelido = model.Apelido;
           Claims = claims;

        }
        public LoginUserDto(){}
    }
}
