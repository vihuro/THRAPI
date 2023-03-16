using Microsoft.AspNetCore.Mvc;
using ThrApi.Service.CustonException;
using ThrApi.Service.JWT;
using ThrAPI.Interface.Login;
using ThrAPI.Dto.Login.Login;

namespace ThrAPI.Controllers.Login
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("create")]
        public ActionResult Create(LoginCreateDto dto)
        {
            try
            {
                var newUser = loginService.Create(dto);
                return Created("", newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ClaimsAuthorizeAttibute("Produto", "ADMIN")]
        public IActionResult OlaDotNet()
        {
            return Ok("aqui, tem todos os segredos da empresa hahahahahahahaha");
        }
        [HttpDelete("Delete-All")]
        public async Task<ActionResult<string>> DeleteAll()
        {
            try
            {
                loginService.DeleteAll();

                return Ok("Usuários deletados com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("user")]
        public async Task<IActionResult> DeleteForUser(Guid id)
        {
            try
            {
                return Ok(loginService.DeleteOneUser(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Logar([FromBody] LoginDto dto)
        {
            try
            {
                var Token = loginService.Logar(dto);

                return Ok(Token);
            }
            catch (ExceptionService ex)
            {
                if (ex.HResult == 404)
                {
                    return NotFound(ex.Message);
                }

                return UnprocessableEntity(ex.Message);
            }

        }

        [HttpGet("SelecUserAll")]
        public IEnumerable<object> SelectAll()
        {

            var list = loginService.SelectAll();
            return list;

        }
    }
}
