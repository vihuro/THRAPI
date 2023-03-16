using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.LocaisEstocagem;
using ThrAPI.Interface.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Service.Estoque
{
    public class LocaisEstocagemService : ILocalEstocagemService
    {
        private readonly ContextBase context;
        private readonly IMapper mapper;
        public LocaisEstocagemService(ContextBase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LocalEstocagemDto AtualizarLocal(AtualizarLocalDto dto)
        {
            throw new NotImplementedException();
        }

        public string DeleteTodosLocais()
        {
            context.LocaisEstocagem.RemoveRange(context.LocaisEstocagem.ToList());
            context.SaveChanges();
            return "Itens excluidos com sucesso!";
        }

        public LocalEstocagemDto InserirLocal(InserirLocalDto dto)
        {
            if(dto.NomeLocal == string.Empty || 
                dto.IdUsuario.ToString() == string.Empty ||
                dto.NumeroLocal == 0 ||
                dto.NomeLocal.Length > 1)
            {
                throw new ExceptionService("Campos obrigatórios vazios");
            }
            var model = new LocaisEstocagemModel()
            {
                NomeLocal = dto.NomeLocal.ToUpper(),
                NumeroLocal = dto.NumeroLocal,
                UsuarioCadastroId = dto.IdUsuario,
                DataHoraCriacao = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.IdUsuario,
                DataHoraAlteracao = DateTime.UtcNow,
                StatusLocal = "ATIVO",
            };
            context.LocaisEstocagem.Add(model);
            context.SaveChanges();
            model = context.LocaisEstocagem
                .Include(u =>u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefault(x => x.Id == model.Id);
            return new(model);
        }

        public List<LocalEstocagemDto> TodosLocais()
        {
            var list = context.LocaisEstocagem
                .Include(c => c.UsuarioCadastro)
                .ToList();
            return mapper.Map<List<LocaisEstocagemModel>, List<LocalEstocagemDto>>(list);
        }
        public LocalEstocagemDto SelectForId(Guid id)
        {
            var obj = context.LocaisEstocagem
                .Include(c => c.UsuarioCadastro)
                .FirstOrDefault(x => x.Id == id);
            return mapper.Map<LocaisEstocagemModel, LocalEstocagemDto>(obj);
        }
    }
}
