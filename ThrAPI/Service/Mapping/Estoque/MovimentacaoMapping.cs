using AutoMapper;
using ThrAPI.Dto.Estoque.Movimentacao;
using ThrAPI.Models.Estoque;

namespace ThrApi.Service.Mapping.Estoque
{
    public class MovimentacaoMapping : Profile
    {
        public MovimentacaoMapping()
        {
            CreateMap<MovimentaoEstoqueModel, MovimentacoesDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.UsuarioMovimentacao , map => map.MapFrom(src => src.UsuarioMovimentacao.NomeUsuario))
                .ForMember(x => x.CodigoMaterial, map => map.MapFrom(src => src.Estoque.Codigo))
                .ForMember(x => x.DescricaoMaterial, map => map.MapFrom(src => src.Estoque.Descricao))
                .ForMember(x => x.Unidade, map => map.MapFrom(src => src.Estoque.Unidade));
        }
    }
}
