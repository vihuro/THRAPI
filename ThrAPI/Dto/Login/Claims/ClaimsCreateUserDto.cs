using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.Claims
{
    public class ClaimsCreateUserDto
    {
        public Guid ClaimId { get; set; }
        public Guid UsuarioId { get; set;}

        public ClaimsCreateUserDto()
        {

        }
    }
}
