using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.IdentificaoMaterial;
using ThrAPI.Dto.Estoque.MovimetacaoIdentificao;
using ThrAPI.Interface.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Service.Estoque
{
    public class MovimentacoIdentificaoService
    {
        private readonly IMapper _mapper;
        private readonly ContextBase _context;
        private readonly IiDentificaoMaterialService _identificaoService;
        private readonly ILocalEstocagemService _localEstocagemService;
        public MovimentacoIdentificaoService(ContextBase context,
                                             IMapper mapper,
                                             IiDentificaoMaterialService identificaoService,
                                             ILocalEstocagemService localEstocagemService)
        {
            _mapper = mapper;
            _context = context;
            _identificaoService = identificaoService;
            _localEstocagemService = localEstocagemService;
        }
        public ReturnIdentificationDto InsertMovimentacao(InsertMovimentacaoIdentificaoDto dto)
        {
            var identificao = _identificaoService.SelectFromId(dto.IdIdentificao);
            if (identificao == null)
            {
                throw new ExceptionService("Identificação não encontrada") { HResult = 404 };
            }
            var local = _localEstocagemService.SelectForId(dto.IdIdentificao);
            if (local == null)
            {
                throw new ExceptionService("Local de estocagem não econtrado!") { HResult = 404 };
            }
            var localOrigem = local.Id;
            var localDestino = dto.LocalEstocagelId;
            var movimentacao = Insert(dto, localOrigem, localDestino);
            UpdateIdentificao(dto, local.Id);

            return SelectFromId(movimentacao.IdentificacaoId);

        }

        public ReturnIdentificationDto UpdateIdentificao(InsertMovimentacaoIdentificaoDto dto, Guid LocalDestino)
        {

            var identificaoAtualizada = new UpdateIdentificaoDto()
            {
                IdentificaoId = dto.IdIdentificao,
                LocalEstocagemId = LocalDestino,
                UsuarioAlteracao = dto.UsuarioMovimentacaoId,
                Quantidade = dto.Quantidade

            };
            var identificao = _identificaoService.UpdateIdentificao(identificaoAtualizada);

            return identificao;
        }
        public ReturnIdentificationDto Insert(InsertMovimentacaoIdentificaoDto dto,
                                             Guid LocalOrigem, Guid LocalDestino)
        {
            var obj = new MovimentacaoIdentificaoModel()
            {
                UsuarioId = dto.UsuarioMovimentacaoId,
                DataHoraMovimentacao = DateTime.UtcNow,
                LocalOrigemId = LocalOrigem,
                LocalDestinoId = LocalDestino,
                QuantidadeMovimentada = dto.Quantidade,
                IdentificaoMaterialId = dto.IdIdentificao
            };
            _context.MovimentacaoIdentificao.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<MovimentacaoIdentificaoModel, ReturnIdentificationDto>(obj);
        }

        public ReturnIdentificationDto SelectFromId(int id)
        {
            var obj = _context.MovimentacaoIdentificao
                .Include(u => u.Usuario)
                .Include(p => p.IdentificaoMaterial.Produto)
                .Include(x => x.IdentificaoMaterial)
                .AsNoTracking()
                .FirstOrDefault(x => x.IdentificaoMaterialId == id);
            return _mapper.Map<MovimentacaoIdentificaoModel, ReturnIdentificationDto>(obj);
        }
    }
}
