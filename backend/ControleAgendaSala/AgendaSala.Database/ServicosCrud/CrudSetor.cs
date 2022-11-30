using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudSetor : CrudBase<Setor>, ICrudSetor
    {
        public CrudSetor(IConexao conexao) : base(conexao)
        {
        }
    }
}
