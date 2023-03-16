namespace ThrAPI.Dto.Login.Claims
{
    public class ClaimsOfUserDto
    {
        public Guid ClaimId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }

        public ClaimsOfUserDto() { }
    }
}
