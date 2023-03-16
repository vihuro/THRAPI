using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThrApi.Interface.Login;
using ThrAPI.Models.Login;
using ThrAPI.Settings;

namespace ThrApi.Service.JWT
{
    public class CreateToken : ICreateTokenService
    {
        private readonly IClaimsService claims;
        private readonly AppSettings appSettings;
        public CreateToken(IClaimsService claims, 
                            IOptions<AppSettings> appSettings)
        {
            this.claims = claims;
            this.appSettings = appSettings.Value;
        }
        public string Create(UsuarioModel user)
        {
            var tokenHeader = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var expirations = appSettings.ExpiracaoHoras;


            var tokenDescriptor = new SecurityTokenDescriptor();

            var listClaimns = claims.ClaimsOfUser(user.Id);
            var claim = new List<Claim>();
            var uniqueName = new Claim(ClaimTypes.Name, user.Apelido);
            var name = new Claim(ClaimTypes.NameIdentifier, user.NomeUsuario);
            var identityName = new Claim("idUser", user.Id.ToString());

            claim.Add(uniqueName);
            claim.Add(name);
            claim.Add(identityName);


            foreach (var item in listClaimns)
            {
              
                claim.Add(new Claim(item.ClaimName, item.ClaimValue));
            }


            tokenDescriptor.Subject = new ClaimsIdentity(claim);


            tokenDescriptor.Expires = DateTime.UtcNow.AddHours(8);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);



            var token = tokenHeader.CreateToken(tokenDescriptor);

            return tokenHeader.WriteToken(token);
        }
    }
}
