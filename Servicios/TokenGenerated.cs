using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Rest_Para_Consulta_de_Datos.Servicios
{
    public class TokenGenerated : ITokenGenerated
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenGenerated(IConfiguration config) 
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(UsuarioAplicacion Usuario, string Role)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Email,Usuario.Email),
                 new Claim(JwtRegisteredClaimNames.GivenName,Usuario.UserName),
                 new Claim(ClaimTypes.Role,Role)
            };

            var Credenciales = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            var DescriptorToken = new SecurityTokenDescriptor 
            { 
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = Credenciales,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(DescriptorToken);
            return TokenHandler.WriteToken(token);
        }
    }
}
