using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrAPI.Models.Login
{
    [Table("tab_ClaimsType")]
    public class ClaimsTypeModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual List<ClaimsModel> ListClaimsOfUser { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadatro { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioAlteracaoId { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public  virtual UsuarioModel UsuarioAlteracao {get;set;}
    }
}
