using AgendaSala.Domain.Entidades;

namespace AgendaSala.Domain.Interfaces
{
    public interface IServicoValidarAgendamento
    {
        bool CompararAgendamentos(Agendamento agendamento, IList<Agendamento> agendamentos);

    }
}
