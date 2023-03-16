using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.Estoque
{
    public class ProdutoEstoqueDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Fornecedor { get; set; }
        public string CategoriaA { get; set; }
        public string CategoriaB { get; set; }
        public string CategoriaC { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public decimal EstoqueSeguranca { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueMaximo { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

        public ProdutoEstoqueDto() { }

        public ProdutoEstoqueDto(EstoqueModel model)
        {
            Id = model.Id;
            Codigo = model.Codigo;
            Descricao = model.Descricao;
            Unidade = model.Unidade;
            Fornecedor = model.Fornecedor;
            CategoriaA = model.CategoriaA;
            CategoriaB = model.CategoriaB;
            CategoriaC = model.CategoriaC;
            QuantidadeEstoque = model.QuantidadeEstoque;
            EstoqueSeguranca = model.EstoqueSeguranca;
            EstoqueMinimo = model.EstoqueMinimo;
            EstoqueMaximo = model.EstoqueMaximo;
            UsuarioCadastro = model.UsuarioCadastro.NomeUsuario;
            DataHoraCadastro = model.DataHoraCadastro;
            UsuarioAlteracao = model.UsuarioAlteracao.NomeUsuario;
            DataHoraAlteracao = model.DataHoraAlteracao;
        }
    }
}
