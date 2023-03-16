using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThrAPI.Models.Login;

namespace ThrAPI.Models.Estoque
{
    [Table("tab_MovimentacaoMaterial")]
    public class MovimentaoEstoqueModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string TipoMovimentacao { get; set; }
        public decimal QuantidadeMovimentada { get; set; }

        public DateTime DataHoraMovimentacao { get; set; }
        public string StatusMovimentacao { get; set; }
        [ForeignKey("tab_Estoque")]
        public Guid EstoqueId { get; set; }
        public virtual EstoqueModel Estoque { get; set; }

        [ForeignKey("tab_Usuario")]
        public Guid UsuarioMovimentacaoId { get; set; }
        public virtual UsuarioModel UsuarioMovimentacao { get; set; }
        [ForeignKey("Tab_IdentificaoMaterial")]
        public Guid? IdentificaoId { get; set; }
        public virtual IdentificaoMaterialModel Identificao { get; set; }
    }
}
