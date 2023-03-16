using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrAPI.Models.Login
{
    [Table("tab_Claims")]
    public class ClaimsModel
    {
        [Key()]
        public Guid Id { get; set; }
        [ForeignKey("tab_ClaimsType")]
        public Guid ClaimsTypeId { get; set; }
        public virtual ClaimsTypeModel ClaimsType {get;set;}
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
