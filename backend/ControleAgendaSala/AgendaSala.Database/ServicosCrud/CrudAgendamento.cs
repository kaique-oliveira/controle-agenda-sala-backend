using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudAgendamento : CrudBase<Agendamento>, ICrudAgendamento
    {
        public CrudAgendamento(IConexao conexao) : base(conexao)
        {
        }
    }
}
