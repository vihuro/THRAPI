namespace ThrAPI.Dto.Login.Claims
{
    public class ReturnClaimsUser
    {
        public Guid ClaimId { get; set; }
        public string NomeUsuario { get; set; }
        public string ClaimValue { get; set; }
        public string ClaimName { get; set; }
        public string Apelido { get; set; }
        public string UsuarioCadstro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string UsuarioAlteracao { get; set; }

        public DateTime DataHoraAlteração { get; set; }


    }
}
