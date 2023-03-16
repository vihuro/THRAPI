using AutoMapper;
using ThrAPI.Dto.Login.ClaimsType;
using ThrAPI.Models.Login;

namespace ThrAPI.Service.Mapping.Login
{
    public class ClaimTypeMapping :Profile
    {
        public ClaimTypeMapping() 
        {
            CreateMap<ClaimsTypeModel, ReturnValueNameClaim>()
                .ForMember(x => x.UsuarioCadastro, map => map.MapFrom(src => src.UsuarioCadastro.NomeUsuario))
                .ForMember(x => x.UsuarioAlteracao, map => map.MapFrom(src => src.UsuarioAlteracao.NomeUsuario));

            /*CreateMap<ReturnValueNameClaim, ClaimsTypeModel>()
                .ForMember(x => x.UsuarioCadastro.NomeUsuario, map => map.MapFrom(src => src.UsuarioCadastro))
                .ForMember(x => x.UsuarioAlteracao.NomeUsuario, map => map.MapFrom(src => src.UsuarioAlteracao));*/
        }
    }
}
