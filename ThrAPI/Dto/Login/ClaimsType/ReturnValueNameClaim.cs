using ThrAPI.Models.Login;

namespace ThrAPI.Dto.Login.ClaimsType
{
    public class ReturnValueNameClaim
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public ReturnValueNameClaim(ClaimsTypeModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Value = model.Value;
            DataHoraCadastro = model.DataHoraCadatro;
            UsuarioCadastro = model.UsuarioCadastro.NomeUsuario;
            DataHoraAlteracao = model.DataHoraAlteracao;
            UsuarioAlteracao = model.UsuarioAlteracao.NomeUsuario;
        } 

        public ReturnValueNameClaim() { }
    }
}
