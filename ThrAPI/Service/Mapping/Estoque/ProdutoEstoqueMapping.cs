using AutoMapper;
using ThrAPI.Dto.Estoque.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrApi.Service.Mapping.Estoque
{
    public class ProdutoEstoqueMapping : Profile
    {
        public ProdutoEstoqueMapping()
        {
           /* CreateMap<EstoqueModel, ProdutoEstoqueDto>()
                .ForMember(x => x.UsuarioCadastro, map => map.MapFrom(src => src.UsuarioCadastro.NomeUsuario))
                .ForMember(x => x.UsuarioAlteracao, map => map.MapFrom(src => src.UsuarioAlteracao.NomeUsuario));

            CreateMap<ProdutoEstoqueDto, EstoqueModel>()
                .ForMember(x => x.UsuarioCadastro.NomeUsuario, map => map.MapFrom(src => src.UsuarioCadastro))
                .ForMember(x => x.UsuarioAlteracao.NomeUsuario, map => map.MapFrom(src => src.UsuarioAlteracao));*/

        }
    }
}
