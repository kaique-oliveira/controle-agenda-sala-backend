using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using AgendaSala.Services.Interfaces;


namespace AgendaSala.Services.Servicos
{
    public class ServicoValidarAgendamento : IServicoValidarAgendamento
    {
        private readonly ICrudAgendamento _crudAgendamento;

        public ServicoValidarAgendamento(ICrudAgendamento crudAgendamento)
        {
            _crudAgendamento = crudAgendamento;
        }

        public bool CompararAgendamentos(Agendamento agendamento)
        {
            var _agendamentos = _crudAgendamento.BuscarTodos()
               .Where(a => a.DataAgendamento.Date == agendamento.DataAgendamento.Date
               && a.HoraInicial.Hour >= agendamento.HoraInicial.Hour
               && a.HoraFinal.Minute <= agendamento.HoraFinal.Minute
               || a.HoraInicial.Hour < agendamento.HoraInicial.Hour
               && a.HoraFinal.Minute <= agendamento.HoraInicial.Minute).ToList();

            //DateTime.Now.ToString("HH:mm:ss");

            return _agendamentos != null ? false : true ;
        }
    }
}
