using AutoMapper;
using ThrAPI.Dto.Estoque.IdentificaoMaterial;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Service.Mapping.Estoque
{
    public class IdentificaoMaterialMapping : Profile
    {
        public IdentificaoMaterialMapping()
        {
            CreateMap<IdentificaoMaterialModel, ReturnIdentificationDto>()
                 //usuario cadastro
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(x => x.UsuarioCadastro.NomeUsuario, map => map.MapFrom(src => src.UsuarioCadastro.NomeUsuario))
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                 //usuario alteração
                .ForPath(x => x.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(x => x.UsuarioAlteracao.NomeUsuario, map => map.MapFrom(src => src.UsuarioAlteracao.NomeUsuario))
                .ForPath(x => x.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido))
                //Produto
                .ForPath(x => x.Produto.Descricao, map => map.MapFrom(src => src.Produto.Descricao))
                .ForPath(x => x.Produto.ProdutoId, map => map.MapFrom(src => src.Produto.Id))
                .ForPath(x => x.Produto.Codigo, map => map.MapFrom(src => src.Produto.Codigo))
                .ForPath(x => x.Produto.Unidade, map => map.MapFrom(src => src.Produto.Unidade))
                //Identificação
                .ForMember(x => x.Densidade, map => map.MapFrom(src => src.Densidade))
                .ForMember(x => x.Quantidade, map => map.MapFrom(src => src.Quantidade))
                .ForMember(x => x.IdentificacaoId, map => map.MapFrom(src => src.Id));
        }
    }
}
