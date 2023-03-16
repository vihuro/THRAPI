using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using ThrApi.Interface.Login;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Controllers.Login;
using ThrAPI.Dto.Login.ClaimsType;
using ThrAPI.Interface.Estoque;
using ThrAPI.Interface.Login;
using ThrAPI.Models.Login;

namespace ThrAPI.Service.Login
{
    public class ClaimsTypeService : IClaimsTypeService
    {
        private readonly ContextBase context;
        private readonly IMapper mapper;
        public ClaimsTypeService(ContextBase context,
                                IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ReturnValueNameClaim> Inserir(InserirClaim dto)
        {
            if(string.IsNullOrEmpty(dto.Value) && string.IsNullOrEmpty(dto.Name))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            dto.Value = dto.Value.ToUpper();
            dto.Name = dto.Name.ToUpper();
            var obj = SearchValueName(dto);
            if (obj.Result != null) 
            {
                throw new ExceptionService("Já existe essa regra!");
            }
            var model = new ClaimsTypeModel
            {
                Name = dto.Name,
                Value = dto.Value,
                DataHoraCadatro = DateTime.UtcNow,
                UsuarioCadastroId = dto.IdUsuario,
                UsuarioAlteracaoId = dto.IdUsuario,
                DataHoraAlteracao = DateTime.UtcNow,
            };
            await context.ClaimsType.AddAsync(model);
            await context.SaveChangesAsync();


            return await SearchValueName(dto);


        }

        public async Task<ReturnValueNameClaim> SearchValueName(InserirClaim dto)
        {
            var obj = context.ClaimsType
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefaultAsync(x => x.Name == dto.Name && x.Value == dto.Value);
            if (obj.Result == null) return null;
            return new(obj.Result);
        }

        public async Task<List<ReturnValueNameClaim>> ListClaims()
        {
            var obj = await context.ClaimsType
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .ToListAsync();
            var list = mapper.Map<List<ClaimsTypeModel>, List<ReturnValueNameClaim>>(obj);
            return list;
        }
        public async Task DeleteAll()
        {
            context.ClaimsType.RemoveRange(context.ClaimsType.ToList());
            context.SaveChanges();
        }

        public ReturnValueNameClaim VerifyClaim(Guid id)
        {
            var claim = context.ClaimsType
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefault(x => x.Id == id);

            return mapper.Map<ClaimsTypeModel, ReturnValueNameClaim>(claim);
        }
    }
}
