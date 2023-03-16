using ThrAPI.Dto.Login.ClaimsType;

namespace ThrAPI.Interface.Login
{
    public interface IClaimsTypeService
    {
        Task<ReturnValueNameClaim> Inserir(InserirClaim dto);
        Task<ReturnValueNameClaim> SearchValueName(InserirClaim dto);
        Task<List<ReturnValueNameClaim>> ListClaims();
        Task DeleteAll();
        ReturnValueNameClaim VerifyClaim(Guid id);
    }
}
