using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThrAPI.Models.Login;

namespace ThrAPI.Models.Estoque
{
    [Table("Tab_LocaisEstocagem")]
    public class LocaisEstocagemModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string NomeLocal { get; set; }
        public int NumeroLocal { get; set; }
        public string StatusLocal { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public DateTime DataHoraAlteracao { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public LocaisEstocagemModel() { }
    }
}
