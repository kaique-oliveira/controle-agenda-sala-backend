﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaSala.Domain.Entidades;
using Microsoft.Extensions.Configuration;


namespace AgendaSala.Auth.Servicos
{
    public static class AuthToken
    {
        
        public static string GerarToken(Usuario usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("usuário", usuario.Nome),
                    new Claim("tipo", usuario.Tipo),
                    new Claim("setor", usuario.Setor.Nome),

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(pegarSecret()), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private static byte[] pegarSecret()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();

            byte[] key = Encoding.ASCII.GetBytes(configuration["KeySecret:Secret"]);

            return key;
        }
    }
}
