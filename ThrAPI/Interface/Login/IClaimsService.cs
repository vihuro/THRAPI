using ThrAPI.Dto.Login.Claims;
using ThrAPI.Dto.Login.Login;
using ThrAPI.Models.Login;

namespace ThrApi.Interface.Login
{
    public interface IClaimsService
    {
        List<ClaimsOfUserDto> NewClaimsUser(List<ClaimsCreateUserDto> dto);
        List<ClaimsOfUserDto> ClaimsOfUser(Guid idUsuairo);
        ClaimsUserAndClaim EditClaimsOfUser(EditClaimsOfUserDto dto);
        ClaimsUserAndClaim SelectUserOfClaims(Guid id);
        ClaimsUserAndClaim DeleteClaimOfUser(Guid id);
        List<ReturnClaimsUser> ListClaimsForUser();
    }
}
