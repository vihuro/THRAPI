using ThrAPI.Dto.Estoque.IdentificaoMaterial;
using ThrAPI.Dto.Estoque.MovimetacaoIdentificao;

namespace ThrAPI.Interface.Estoque
{
    public interface IMovimentacaoIdentificaoService
    {
        ReturnIdentificationDto InsertMovimentacao(InsertMovimentacaoIdentificaoDto dto);
        public ReturnIdentificationDto SelectFromId(Guid id);

    }
}
