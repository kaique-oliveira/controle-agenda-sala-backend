using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaSala.Domain.Entidades;
using Microsoft.Extensions.Configuration;
using AgendaSala.Auth.Interfaces;

namespace AgendaSala.Auth.Servicos
{
    public class AuthToken : IAuthToken
    {
        private readonly IConfigurationRoot configuration;
        public AuthToken()
        {
            configuration =  new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();

        }

        public string GerarToken(Usuario usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim("id", usuario.Id.ToString()),
                    new Claim("nome", usuario.Nome),
                    new Claim("email", usuario.Email),
                    new Claim("tipo", usuario.Tipo),

                }),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["KeySecret:Secret"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken lerToken(ModelToken token)
        {
            var jwt = token.Token;
            var handler = new JwtSecurityTokenHandler();
            var _token = handler.ReadJwtToken(jwt);

            return _token;
        }

    }
}
