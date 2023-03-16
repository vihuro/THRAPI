using AutoMapper;
using ThrAPI.Dto.Login.Claims;
using ThrAPI.Models.Login;

namespace ThrApi.Service.Mapping.Login
{
    public class ClaimsMapping : Profile
    {
        public ClaimsMapping()
        {
            CreateMap<ClaimsModel, ClaimsOfUserDto>()
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.ClaimsType.Name))
                .ForMember(x => x.ClaimName, map => map.MapFrom(src => src.ClaimsType.Value))
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.Id));
            CreateMap<ClaimsOfUserDto, ClaimsModel>();
            CreateMap<ClaimsModel, ReturnClaimsUser>()
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.ClaimsType.Value))
                .ForMember(x => x.ClaimName, map => map.MapFrom(src => src.ClaimsType.Name))
                .ForMember(x => x.UsuarioCadstro, map => map.MapFrom(src => src.UsuarioCadastro.NomeUsuario))
                .ForMember(x => x.NomeUsuario, map => map.MapFrom(src => src.Usuario.NomeUsuario))
                .ForMember(x => x.UsuarioAlteracao, map => map.MapFrom(src => src.UsuarioAlteracao.NomeUsuario))
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.ClaimsType.Id))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Usuario.Apelido))
                .ForMember(x => x.DataHoraAlteração, map => map.MapFrom(src => src.DataHoraAlteracao))
                ;
        }
    }
}
