using ThrAPI.Models.Estoque;

namespace ThrAPI.Dto.Estoque.LocaisEstocagem
{
    public class LocalEstocagemDto
    {
        public Guid Id { get; set; }
        public string NomeLocal { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string StatusLocal { get; set; }
        public LocalEstocagemDto(LocaisEstocagemModel model)
        {
            this.Id = model.Id;
            this.NomeLocal = $"{model.NomeLocal}-{model.NumeroLocal}";
            this.UsuarioCadastro = model.UsuarioCadastro.NomeUsuario;
            this.DataHoraCriacao = model.DataHoraCriacao;
            this.UsuarioAlteracao = model.UsuarioAlteracao.NomeUsuario;
            this.DataHoraAlteracao = model.DataHoraAlteracao;
            this.StatusLocal = model.StatusLocal;
        }
    }
}
