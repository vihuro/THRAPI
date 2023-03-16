namespace ThrAPI.Dto.Login.Claims
{
    public class EditClaimsOfUserDto
    {
        public Guid ClaimsId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        
        public EditClaimsOfUserDto() { }
    }
}
