using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudSala : CrudBase<Sala>, ICrudSala
    {
        public CrudSala(IConexao conexao) : base(conexao)
        {
        }
    }
}
