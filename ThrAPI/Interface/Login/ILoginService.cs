using System.Security.Claims;
using ThrAPI.Dto.Login.Login;

namespace ThrAPI.Interface.Login
{
    public interface ILoginService
    {
        string Logar(LoginDto dto);
        LoginUserDto Create(LoginCreateDto dto);
        void DeleteAll();
        List<LoginUserDto> SelectAll();
        string DeleteOneUser(Guid id);
    }
}
