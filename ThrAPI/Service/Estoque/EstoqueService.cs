using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThrApi.Service.CustonException;
using ThrAPI.Context;
using ThrAPI.Dto.Estoque.Estoque;
using ThrAPI.Interface.Estoque;
using ThrAPI.Models.Estoque;

namespace ThrAPI.Service.Estoque
{
    public class EstoqueService : IEstoqueService
    {
        private readonly ContextBase context;
        private readonly IMapper mapper;
        public EstoqueService(ContextBase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<EstoqueModel> AlterarProduto(ProdutoEstoqueDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEstoqueDto> BuscarPorCodigo(string codigo)
        {
            var obj = await context.Estoque
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefaultAsync(x => x.Codigo == codigo.ToUpper());
            if (obj == null)
            {
                //throw new ExceptionService("Material não encontrado!") { HResult = 404};
            }

            return new ProdutoEstoqueDto(obj);
        }

        public async Task<ProdutoMovimentacaoDto> BuscarMovimentacao(string codigo)
        {
            var obj = await context.Estoque.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (obj == null)
            {
                throw new ExceptionService("Material não encontrado!");
            }
            return new ProdutoMovimentacaoDto(obj);
        }

        public async Task<NovoProdutoDto> CadastrarProduto(CadastroProdutoDto dto)
        {
            var obj = await context
                .Estoque
                .FirstOrDefaultAsync(x => x.Codigo == dto.Codigo);
            if (obj != null)
            {
                throw new ExceptionService("Código já cadastrado!");
            }
            if (!ValidarEstoque(dto.EstoqueMinimo, dto.EstoqueMaximo, dto.EstoqueSeguranca))
            {
                throw new ExceptionService("Erro ao valídar estoque maxímo, mínimo e estoque de segurança!");
            }
            var model = new EstoqueModel()
            {
                Codigo = dto.Codigo.ToUpper(),
                Descricao = dto.Descricao.ToUpper(),
                Fornecedor = dto.Fornecedor.ToUpper(),
                CategoriaA = dto.CategoriaA.ToUpper(),
                CategoriaB = dto.CategoriaB.ToUpper(),
                CategoriaC = dto.CategoriaC.ToUpper(),
                EstoqueMaximo = dto.EstoqueMaximo,
                EstoqueMinimo = dto.EstoqueMinimo,
                Unidade = dto.Unidade.ToUpper(),
                EstoqueSeguranca = dto.EstoqueSeguranca,
                UsuarioCadastroId = dto.UsuarioCadastro,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastro,
                DataHoraAlteracao = DateTime.UtcNow
            };

            await context.Estoque.AddAsync(model);
            await context.SaveChangesAsync();

            var novoObj = await BuscarPorCodigo(model.Codigo);
            model.UsuarioAlteracao.NomeUsuario = novoObj.UsuarioAlteracao;
            model.UsuarioCadastro.NomeUsuario = novoObj.UsuarioCadastro;

            return new (model);

        }

        public bool ValidarEstoque(decimal estoqueMinimo, decimal estoqueMaximo, decimal estoqueSeguranca)
        {
            if (estoqueMaximo > estoqueSeguranca &&
                estoqueMaximo > estoqueMinimo &&
                estoqueSeguranca > estoqueMinimo) return true;

            return false;


            /*if (estoqueMinimo > estoqueMaximo)
            {
                return false;
            }
            else if (estoqueSeguranca > estoqueMaximo)
            {
                return false;
            }
            else if (estoqueMinimo < 0)
            {
                return false;
            }

            return true;*/

        }

        public async Task<EstoqueModel> DeletarProduto(Guid id)
        {
            var obj = context.Estoque.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                throw new ExceptionService("Produto não cadastrado!");
            }

            context.Estoque.Remove(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async void DeletarTodosProdutos()
        {
            var list = await context.Estoque.ToListAsync();
            foreach (var obj in list)
            {
                context.Estoque.Remove(obj);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<ProdutoEstoqueDto>> ObterProdutosEstoque()
        {
            var model = await context.Estoque.ToListAsync();
            var list = mapper.Map<List<EstoqueModel>, List<ProdutoEstoqueDto>>(model);
            return list;
        }

        public async Task<ProdutoEstoqueDto> UpdateEstoque(Guid id, decimal quantidadeMovimentada)
        {
            var obj = context.Estoque.FirstOrDefault(x => x.Id == id);
            obj.QuantidadeEstoque += quantidadeMovimentada;
            if (obj.QuantidadeEstoque < 0)
            {
                throw new ExceptionService("Não é possível fazer essa movimentação! A quantidade em estoque ficará negativa.");
            }
            context.Estoque.Update(obj);
            await context.SaveChangesAsync();

            return new ProdutoEstoqueDto(obj);

        }
    }
}
