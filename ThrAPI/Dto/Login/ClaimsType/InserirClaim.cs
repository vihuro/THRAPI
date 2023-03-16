using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.ClaimsType
{
    public class InserirClaim
    {
        public string Value { get; set; }
        public string Name { get; set; }
        public Guid IdUsuario { get; set; }

    }
}
