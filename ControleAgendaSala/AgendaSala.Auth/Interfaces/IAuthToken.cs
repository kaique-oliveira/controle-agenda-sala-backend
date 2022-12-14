using AgendaSala.Domain.Entidades;
using System.IdentityModel.Tokens.Jwt;


namespace AgendaSala.Auth.Interfaces
{
    public interface IAuthToken
    {
        string GerarToken(Usuario usuario);

        JwtSecurityToken lerToken(ModelToken token);

    }
}
