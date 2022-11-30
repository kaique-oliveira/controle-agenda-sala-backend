using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudUsuario : CrudBase<Usuario>, ICrudUsuario
    {
        public CrudUsuario(IConexao conexao) : base(conexao)
        {
        }
    }
}
