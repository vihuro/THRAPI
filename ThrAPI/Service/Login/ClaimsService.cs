using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ThrApi.Interface.Login;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Controllers.Login;
using ThrAPI.Dto.Login.Claims;
using ThrAPI.Dto.Login.ClaimsType;
using ThrAPI.Dto.Login.Login;
using ThrAPI.Interface.Login;
using ThrAPI.Models.Login;
using ThrAPI.Service.Login;

namespace ThrApi.Service.Login
{
    public class ClaimsService : IClaimsService
    {
        private readonly ContextBase context;
        private readonly IMapper mapper;
        private readonly IClaimsTypeService claimsTypeService;
        private readonly ILoginService loginService;
        public ClaimsService(ContextBase context,
                            IMapper mapper,
                            IClaimsTypeService claimsTypeService)
        {
            this.context = context;
            this.mapper = mapper;
            this.claimsTypeService = claimsTypeService;
            
        }


        //Esse metodo recebe ID da Claim e Id do usuário e retorna apenas os valores das claims
        public List<ClaimsOfUserDto> NewClaimsUser(List<ClaimsCreateUserDto> dto)
        {
            var obj = new List<ClaimsModel>();
            var idUsuario = new Guid();
            foreach (var item in dto)
            {
                idUsuario = item.UsuarioId;

                obj.Add(new ClaimsModel
                {
                    ClaimsTypeId = item.ClaimId,
                    UsuarioId = item.UsuarioId,
                    UsuarioCadastroId = item.UsuarioId,
                    DataHoraCadastro = DateTime.UtcNow,
                    UsuarioAlteracaoId = item.UsuarioId,
                    DataHoraAlteracao = DateTime.UtcNow

                });
            }
            context.Claims.AddRangeAsync(obj);
            context.SaveChangesAsync();
            var list = ClaimsOfUser(idUsuario);
            return list;
        }

        public List<ClaimsOfUserDto> ClaimsOfUser(Guid idUsuairo)
        {
            var claims = context.Claims
                .Include(c => c.ClaimsType)
                .Where(x => x.UsuarioId == idUsuairo)
                .ToList();
            var list = mapper.Map<List<ClaimsModel>, List<ClaimsOfUserDto>>(claims);
            return list;

        }


        public ClaimsUserAndClaim EditClaimsOfUser(EditClaimsOfUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.ClaimsId.ToString()) && string.IsNullOrEmpty(dto.UsuarioId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigaório(s) vazio(s)!");
            }


            var claimsOfUserDtos = context.Claims
                .Include(c => c.ClaimsType)
                .AsNoTracking()
                .Where(x => x.Usuario.Id == dto.UsuarioId)
                .ToList();

            var claimSolict = claimsTypeService
                .VerifyClaim(dto.ClaimsId);
            if (claimSolict == null)
            {
                throw new ExceptionService("Claim não econtrada!") { HResult = 404 };

            };

            var item = claimsOfUserDtos
                       .Where(v => v.ClaimsType.Value == claimSolict.Value)
                       .FirstOrDefault();
            UpdateClaimsOfUser(item, dto);

            return SelectUserOfClaims(dto.UsuarioId);
        }

        public ClaimsUserAndClaim SelectUserOfClaims(Guid id)
        {
            var claims = context.Claims
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == id)
                .ToList();

            var user = claims
                .Where(x => x.Usuario.Id == id)
                .FirstOrDefault();
            var list = mapper.Map<List<ClaimsModel>, List<ClaimsOfUserDto>>(claims);

            if(user == null)
            {
                throw new ExceptionService("Usuário sem claims!") { HResult = 404 };

            }

            return new(user.Usuario.NomeUsuario,user.Usuario.Apelido,list);
            
        }

        private void UpdateClaimsOfUser(ClaimsModel item, EditClaimsOfUserDto dto)
        {
            var model = new ClaimsModel();
            model.DataHoraAlteracao = DateTime.UtcNow;
            model.UsuarioAlteracaoId = dto.UsuarioCadastroId;
            model.ClaimsTypeId = dto.ClaimsId;
            model.UsuarioId = dto.UsuarioId;
            if (item != null)
            {
                model.Id = item.Id;
                model.UsuarioCadastroId = item.UsuarioCadastroId;
                model.DataHoraCadastro = item.DataHoraCadastro;
                context.Claims.Update(model);
            }
            else
            {
                model.UsuarioCadastroId = dto.UsuarioCadastroId;
                model.DataHoraCadastro = DateTime.UtcNow;
                context.Claims.Add(model);
            }

            context.SaveChanges();

            //return mapper.Map<ClaimsModel, ClaimsOfUserDto>(model);

        }

        public ClaimsUserAndClaim DeleteClaimOfUser(Guid id)
        {
            var claim = context.Claims
                .Include(u => u.Usuario)
                .Include(c => c.ClaimsType)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (claim != null) 
            {
                context.Claims.RemoveRange(claim);
                context.SaveChanges();
            }
            return SelectUserOfClaims(claim.Usuario.Id);
        }

        public List<ReturnClaimsUser> ListClaimsForUser()
        {
            var list = context.Claims
                .Include(u => u.Usuario)
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(c => c.ClaimsType)
                .ToList();

            return mapper.Map<List<ClaimsModel>,List<ReturnClaimsUser>>(list);
        }
    }
}
