using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThrAPI.Models.Login;

namespace ThrAPI.Models.Estoque
{
    [Table("tab_MovimentacaoIdentificacao")]
    public class MovimentacaoIdentificaoModel
    {
        [Key()]
        public Guid Id { get; set; }
        [ForeignKey("Tab_IdentificaoMaterial")]
        public Guid IdentificaoMaterialId { get; set; }
        public virtual IdentificaoMaterialModel IdentificaoMaterial { get; set; }
        public Guid UsuarioId { get; set; }
        [ForeignKey("tab_Usuario")]
        public virtual UsuarioModel Usuario {get;set;}
        public DateTime DataHoraMovimentacao { get; set; }
        public decimal QuantidadeMovimentada { get; set; }
        [ForeignKey("Tab_LocaisEstocagem")]
        public Guid LocalOrigemId { get; set; }
        public virtual LocaisEstocagemModel LocalOrigem { get; set; }
        [ForeignKey("Tab_LocaisEstocagem")]
        public Guid LocalDestinoId { get; set; }
        public  virtual LocaisEstocagemModel LocalDestino { get; set; }

    }
}
