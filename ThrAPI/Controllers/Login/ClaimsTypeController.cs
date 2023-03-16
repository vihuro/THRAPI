using Microsoft.AspNetCore.Mvc;
using ThrAPI.Dto.Login.ClaimsType;
using ThrAPI.Interface.Login;

namespace ThrAPI.Controllers.Login
{
    [ApiController]
    [Route("api/claims")]
    public class ClaimsTypeController : ControllerBase
    {
        private readonly IClaimsTypeService service;
        public ClaimsTypeController(IClaimsTypeService service) => this.service = service;
        [HttpGet]
        public async Task<IActionResult> ListClaims()
        {
            try
            {
                var obj = await service.ListClaims();
                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InserirClaim dto)
        {
            try
            {
                return Ok(await service.Inserir(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                return Ok(service.DeleteAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
