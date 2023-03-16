using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.Movimentacao;
using ThrAPI.Interface.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrApi.Service.Estoque
{
    public class MovimentacaoService : IMovimentacaoEstoqueService
    {
        private readonly ContextBase context;
        private readonly IMapper mapper;
        private readonly IEstoqueService estoqueService;

        public MovimentacaoService(ContextBase context, 
                                    IMapper mapper, 
                                    IEstoqueService produtoService)
        {
            this.context = context;
            this.mapper = mapper;
            this.estoqueService = produtoService;
        }

        public async Task<List<MovimentacoesDto>> FindAll()
        {

            var model = await context.Movimentacao
                .Include(u => u.UsuarioMovimentacao)
                .Include(e => e.Estoque)
                .ToListAsync();

            return mapper.Map<List<MovimentaoEstoqueModel>, List<MovimentacoesDto>>(model);
        }

        public async Task<List<MovimentacoesDto>> BuscarPorCodigo(string codigo)
        {
            var movimentacoes = await context.Movimentacao
                .Include(u => u.UsuarioMovimentacao)
                .Include(e => e.Estoque)
                .Where(x => x.Estoque.Codigo == codigo.ToUpper())
                .ToListAsync();
            if (movimentacoes.Count == 0)
            {
                throw new ExceptionService("Código não encontrado")
                { HResult = 404 };
            }
            return mapper
                .Map<List<MovimentaoEstoqueModel>,
                List<MovimentacoesDto>>(movimentacoes);
        }

        public async Task<RetornoMovimentacaoDto> Insert(NovaMovimentacaoDto dto)
        {
            if (dto.CodigoMaterial == string.Empty && dto.TipoMovimentacao == string.Empty &&
                dto.UsuarioMovimentacao.ToString() == string.Empty)
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            else if (dto.TipoMovimentacao != "SAÍDA" && dto.TipoMovimentacao != "ENTRADA")
            {
                throw new ExceptionService("Não foi possivel realizar essa operação!");
            }
            var material = await estoqueService.BuscarPorCodigo(dto.CodigoMaterial);

            if (material == null)
            {
                throw new ExceptionService("Código não encontrado!");
            }

            var model = new MovimentaoEstoqueModel()
            {
                TipoMovimentacao = dto.TipoMovimentacao,
                StatusMovimentacao = "NORMAL",
                QuantidadeMovimentada = dto.QuantidadeMovimentada,
                DataHoraMovimentacao = DateTime.UtcNow,
                UsuarioMovimentacaoId = dto.UsuarioMovimentacao,
                EstoqueId = material.Id

            };
            return await Movimentacao(model, material.Id);
        }
        public async Task<RetornoMovimentacaoDto> Movimentacao(MovimentaoEstoqueModel estoque, Guid id)
        {
            if (estoque.TipoMovimentacao == "SAÍDA")
            {
                estoque.QuantidadeMovimentada *= -1;
            }
            await estoqueService.UpdateEstoque(id, estoque.QuantidadeMovimentada);
            await context.Movimentacao.AddAsync(estoque);
            await context.SaveChangesAsync();

            return new(estoque);

        }
    }
}
