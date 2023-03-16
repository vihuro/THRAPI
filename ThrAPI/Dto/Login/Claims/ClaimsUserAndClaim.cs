using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.Claims
{
    public class ClaimsUserAndClaim
    {
        public string NomeUsuario { get; set; }
        public string  Apelido { get; set; }
        public List<ClaimsOfUserDto> Claims {get;set;}

        public ClaimsUserAndClaim(string NomeUsuario, string Apelido, List<ClaimsOfUserDto> Claims)
        {
            this.NomeUsuario = NomeUsuario;
            this.Apelido = Apelido;
            this.Claims = Claims;
        }

        public ClaimsUserAndClaim() { }
    }
}
