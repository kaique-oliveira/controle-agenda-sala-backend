using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudUsuario : CrudBase<Usuario>, ICrudUsuario
    {
        public CrudUsuario(IConexao conexao) : base(conexao)
        {
        }

    }
}
