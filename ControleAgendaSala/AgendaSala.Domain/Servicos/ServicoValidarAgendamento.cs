using AgendaSala.Domain.Entidades;
using AgendaSala.Domain.Interfaces;


namespace AgendaSala.Domain.Servicos
{
    public class ServicoValidarAgendamento : IServicoValidarAgendamento
    {

        public bool CompararAgendamentos(Agendamento agendamento, IList<Agendamento> listaAgendamento)
        {
            bool isDisponivel = true;
            var _agendamentos = listaAgendamento
                .Where(a =>
                agendamento.DataAgendamento.Date == a.DataAgendamento.Date
                && agendamento.Sala.Id == a.Sala.Id 
                && agendamento.Id != a.Id).ToList();


            if (_agendamentos.Count != 0) {
                var entreHorario = _agendamentos.Where(a =>
                    agendamento.HoraInicial.TimeOfDay >=  a.HoraInicial.TimeOfDay
                    && agendamento.HoraFinal.TimeOfDay <= a.HoraFinal.TimeOfDay
                ).ToList();

                var horaAntes = _agendamentos.Where(a =>
                    agendamento.HoraInicial.TimeOfDay < a.HoraInicial.TimeOfDay
                    && agendamento.HoraFinal.TimeOfDay >  a.HoraInicial.TimeOfDay
                ).ToList();

                var horaDepois = _agendamentos.Where(a =>
                     agendamento.HoraInicial.TimeOfDay >=  a.HoraInicial.TimeOfDay
                     && agendamento.HoraInicial.TimeOfDay <  a.HoraFinal.TimeOfDay

                ).ToList();

                if (entreHorario.Count != 0 || horaAntes.Count != 0 || horaDepois.Count != 0) {
                    isDisponivel = false;
                }

            }

            return isDisponivel ;
        }
    }
}
