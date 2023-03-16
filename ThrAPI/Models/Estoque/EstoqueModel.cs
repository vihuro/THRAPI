using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ThrAPI.Models.Login;

namespace ThrAPI.Models.Estoque
{
    [Table("tab_Estoque")]
    public class EstoqueModel
    {
        [Key()]
        public Guid Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Unidade { get; set; }
        [Required]
        public string Fornecedor { get; set; }
        [Required]
        public string CategoriaA { get; set; }
        [AllowNull]
        public string CategoriaB { get; set; }
        [AllowNull]
        public string CategoriaC { get; set; }
        [Required]
        public decimal QuantidadeEstoque { get; set; }
        [Required]
        public decimal EstoqueSeguranca { get; set; }
        [Required]
        public decimal EstoqueMinimo { get; set; }
        [Required]
        public decimal EstoqueMaximo { get; set; }
        [Required]
        [ForeignKey("tab_Usuario")]

        public Guid UsuarioCadastroId { get; set; }
        [Required]
        public DateTime DataHoraCadastro { get; set; }
        [Required]
        [ForeignKey("tab_Usuario")]
        public Guid UsuarioAlteracaoId { get; set; }
        [Required]
        public DateTime DataHoraAlteracao { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }

    }
}
