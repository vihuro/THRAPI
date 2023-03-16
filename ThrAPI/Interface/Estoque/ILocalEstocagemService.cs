using ThrAPI.Dto.Estoque.LocaisEstocagem;

namespace ThrAPI.Interface.Estoque
{
    public interface ILocalEstocagemService
    {
        LocalEstocagemDto InserirLocal(InserirLocalDto dto);
        List<LocalEstocagemDto> TodosLocais();
        string DeleteTodosLocais();
        LocalEstocagemDto AtualizarLocal(AtualizarLocalDto dto);
        LocalEstocagemDto SelectForId(Guid id);
    }
}
