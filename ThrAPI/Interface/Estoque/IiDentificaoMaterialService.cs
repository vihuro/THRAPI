using ThrAPI.Dto.Estoque.IdentificaoMaterial;

namespace ThrAPI.Interface.Estoque
{
    public interface IiDentificaoMaterialService
    {
        ReturnIdentificationDto Insert(CreateIdentificationDto dto);
        List<ReturnIdentificationDto> SelectList();
        ReturnIdentificationDto SelectFromId(int id);
        ReturnIdentificationDto UpdateIdentificao(UpdateIdentificaoDto dto);
        string DeleteAll();

    }
}
