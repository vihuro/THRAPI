using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.IdentificaoMaterial;
using ThrAPI.Interface.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Service.Estoque
{
    public class IdentificacaoMaterialService : IiDentificaoMaterialService
    {
        private readonly ContextBase context;
        private readonly IEstoqueService estoqueService;
        private readonly IMapper mapper;
        public IdentificacaoMaterialService(ContextBase context,
                                            IEstoqueService estoqueService,
                                            IMapper mapper)
        {
            this.context = context;
            this.estoqueService = estoqueService;
            this.mapper = mapper;
        }
        public ReturnIdentificationDto Insert(CreateIdentificationDto dto)
        {
            if(string.IsNullOrEmpty(dto.UsuarioId.ToString()) || 
                string.IsNullOrEmpty(dto.Codigo) || 
                string.IsNullOrEmpty(dto.Lote))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var produto = estoqueService.BuscarPorCodigo(dto.Codigo);
            if(produto.Result == null)
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!") {HResult=404 };
            }
            var obj = new IdentificaoMaterialModel()
            {
                ProdutoId = produto.Result.Id,
                Lote = dto.Lote,
                IF = dto.IF,
                Densidade = dto.Densidade,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioCadastroId = dto.UsuarioId,
                DataHoraAlteracao = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioId,
                PesoBruto = dto.PesoBruto,
                PesoPalete = dto.PesoPalete,
                PesoLiquido = dto.PesoBruto - dto.PesoPalete,
            };
            context.IdentificaoMaterial.Add(obj);
            context.SaveChanges();

            return SelectFromId(obj.Id);
        }

        public ReturnIdentificationDto SelectFromId(int id)
        {
            var obj = context.IdentificaoMaterial
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(p => p.Produto)
                .Include(l => l.LocalEstocagem)
                .FirstOrDefault(x => x.Id == id);
            return mapper.Map<IdentificaoMaterialModel, ReturnIdentificationDto>(obj);

        }

        public List<ReturnIdentificationDto> SelectList()
        {
            var obj = context.IdentificaoMaterial
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(p => p.Produto)
                .Include(l => l.LocalEstocagem)
                .ToList();
            return mapper.Map<List<IdentificaoMaterialModel>, List<ReturnIdentificationDto>>(obj);
        }

        public ReturnIdentificationDto UpdateIdentificao(UpdateIdentificaoDto dto)
        {
            if(string.IsNullOrEmpty(dto.IdentificaoId.ToString()) ||
                string.IsNullOrEmpty(dto.UsuarioAlteracao.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var identificao = SelectFromId(dto.IdentificaoId);
            var obj = new IdentificaoMaterialModel()
            {
                Id = identificao.IdentificacaoId,
                Quantidade = dto.Quantidade,
                UsuarioCadastroId = identificao.UsuarioCadastro.UsuarioId,
                DataHoraCadastro = identificao.DataHoraCadastro,
                UsuarioAlteracaoId = dto.UsuarioAlteracao,
                DataHoraAlteracao = DateTime.UtcNow,
                IF = identificao.IF,
                ProdutoId = identificao.Produto.ProdutoId,
                Densidade = identificao.Densidade,
                PesoPalete = identificao.PesoPalete,
                LocalEstocagemId = dto.LocalEstocagemId,
                PesoBruto = identificao.PesoBruto,
                PesoLiquido = identificao.PesoLiquido,
                Lote = identificao.Lote,
            };
            context.IdentificaoMaterial.Update(obj);
            context.SaveChanges();

            return mapper.Map<IdentificaoMaterialModel, ReturnIdentificationDto>(obj);

        }

        public string DeleteAll()
        {
            context.IdentificaoMaterial.RemoveRange(context.IdentificaoMaterial.ToList());
            context.SaveChanges();
            return "Identificações excluidas com sucesso!";
        }
    }
}
