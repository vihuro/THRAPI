using ThrAPI.Models.Login;

namespace ThrApi.Interface.Login
{
    public interface ICreateTokenService
    {
        public string Create(UsuarioModel user);
    }
}
