using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThrAPI.Models.Login;

namespace ThrAPI.Models.Estoque
{
    [Table("Tab_IdentificaoMaterial")]
    public class IdentificaoMaterialModel
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("tab_Estoque")]
        public Guid ProdutoId { get; set; }
        public virtual EstoqueModel Produto { get; set; }
        public string? Lote { get; set; }
        public decimal? PesoPalete { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public decimal? Quantidade { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string? IF {get;set;}
        public decimal? Densidade { get; set; }
        [ForeignKey("Tab_LocaisEstocagem")]
        public Guid? LocalEstocagemId { get; set; }
        public virtual LocaisEstocagemModel LocalEstocagem { get; set; }
        [ForeignKey("tab_MovimentacaoIdentificacao")]
        public virtual List<MovimentacaoIdentificaoModel> MovimentacaoIdentificao { get; set; }
    }
}
