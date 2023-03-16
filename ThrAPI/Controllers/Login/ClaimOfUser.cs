using Microsoft.AspNetCore.Mvc;
using ThrApi.Interface.Login;
using ThrAPI.Dto.Login.Claims;
using ThrAPI.Dto.Login.Login;

namespace ThrAPI.Controllers.Login
{
    [ApiController]
    [Route("api/login/claims")]
    public class ClaimOfUser : ControllerBase
    {
        private readonly IClaimsService service;
        public ClaimOfUser(IClaimsService service)
        {
            this.service = service;
        }

        [HttpPut]
        public ActionResult<LoginUserDto> ClaimsOfUserEdit([FromBody] EditClaimsOfUserDto dto)
        {
            try
            {
                return Ok(service.EditClaimsOfUser(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public ActionResult<string> DeleteClaimsOfUser(Guid id)
        {
            try
            {
                service.DeleteClaimOfUser(id);
                return Ok("Claim deletada com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<List<ReturnClaimsUser>> ListClaimsForUser()
        {
            try
            {
                return Ok(service.ListClaimsForUser());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
