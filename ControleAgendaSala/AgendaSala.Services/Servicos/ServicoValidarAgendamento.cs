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
                .Where(a => 
                a.DataAgendamento.Date == agendamento.DataAgendamento.Date
                && agendamento.HoraInicial.TimeOfDay >=  a.HoraInicial.TimeOfDay
                && agendamento.HoraFinal.TimeOfDay <= a.HoraFinal.TimeOfDay
                || agendamento.HoraFinal.TimeOfDay >= a.HoraFinal.TimeOfDay 

                || agendamento.HoraInicial.TimeOfDay < a.HoraInicial.TimeOfDay
                && agendamento.HoraFinal.TimeOfDay >  a.HoraInicial.TimeOfDay
                ).ToList();


            return _agendamentos.Count != 0 ? false : true ;
        }
    }
}
