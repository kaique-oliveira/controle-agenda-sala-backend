using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;


namespace AgendaSala.Services.Interfaces
{
    public interface IServicoValidarAgendamento
    {
        bool CompararAgendamentos(Agendamento agendamento);

    }
}
