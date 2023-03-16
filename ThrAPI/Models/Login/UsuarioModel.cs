using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThrAPI.Models.Login
{
    [Table("tab_Usuario")]
    public class UsuarioModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }

    }
}
