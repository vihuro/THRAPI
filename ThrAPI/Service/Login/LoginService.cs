using ThrApi.Interface.Login;
using ThrApi.Service.CustonException;
using System.Security.Claims;
using AutoMapper;
using ThrAPI.Interface.Login;
using ThrAPI.Models.Login;
using ThrAPI.Context;
using ThrAPI.Dto.Login.Login;
using ThrAPI.Dto.Login.Claims;


namespace ThrApi.Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly ContextBase context;
        private readonly IClaimsService claimsService;
        private readonly ICreateTokenService createToken;
        private readonly IMapper mapper;
        public LoginService(ContextBase context,
            IClaimsService claimsService,
            IMapper mapper,
            ICreateTokenService createToken)
        {
            this.context = context;
            this.claimsService = claimsService;
            this.createToken = createToken;
        }

        public string Logar(LoginDto dto)
        {
            try
            {
                var User = context.Usuario.FirstOrDefault(x => x.Apelido == dto.Apelido.ToLower());
                if (User == null)
                {
                    throw new ExceptionService("Usuário ou senha inválidos!")
                    {
                        HResult = 404
                    };
                }

                var Valid = BCrypt.Net.BCrypt.Verify(dto.Senha, User.Senha);

                if (!Valid)
                {
                    throw new ExceptionService("Usuário ou senha inválidos!")
                    {
                        HResult = 404
                    };
                }

                var token = createToken.Create(User);

                return token;
            }
            catch (ExceptionService ex)
            {
                throw new ExceptionService(ex.Message) { HResult = ex.HResult };
            }


        }



        public LoginUserDto Create(LoginCreateDto dto)
        {
            var Valid = VerifyUser(dto.Apelido);
            if (Valid)
            {
                throw new ExceptionService("Usuário já cadastrado!");
            }
            var model = new UsuarioModel();
            model.NomeUsuario = dto.NomeUsuario;
            model.Apelido = dto.Apelido;
            model.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            context.Usuario.AddAsync(model);
            context.SaveChangesAsync();

            var listClaims = new List<ClaimsCreateUserDto>();

            foreach (var item in dto.Claims)
            {
                var list = new ClaimsCreateUserDto()
                {
                    ClaimId = item.ClaimId,
                    UsuarioId = model.Id
                };
                listClaims.Add(list);
            }

            var claimsReturn = claimsService.NewClaimsUser(listClaims);

            return new LoginUserDto(model, claimsReturn);

        }

        public List<LoginUserDto> SelectAll()
        {
            var listUsers = context.Usuario.ToList();

            var dto = new List<LoginUserDto>();

            foreach (var itens in listUsers)
            {

                var claims = claimsService.ClaimsOfUser(itens.Id);

                dto.Add(new LoginUserDto
                {
                    Apelido = itens.Apelido,
                    NomeUsuario = itens.NomeUsuario,
                    Id = itens.Id,
                    Claims = claims
                });
            }

            return dto;
        }

        public string DeleteOneUser(Guid id)
        {
            var user = context.Usuario.FirstOrDefault(x => x.Id == id);
            context.Usuario.Remove(user);
            context.SaveChangesAsync();
            return "Usuário deletado com sucesso!";
        }
        private bool VerifyUser(string apelido)
        {
            var User = context.Usuario.FirstOrDefault(x => x.Apelido == apelido);
            if (User != null)
            {
                return true;
            }
            return false;
        }
        public void DeleteAll()
        {
            context.Usuario.RemoveRange(context.Usuario.ToList());
            context.SaveChanges();

        }


    }
}
