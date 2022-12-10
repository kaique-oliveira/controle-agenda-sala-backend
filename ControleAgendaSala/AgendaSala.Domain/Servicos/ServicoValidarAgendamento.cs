using AgendaSala.Domain.Entidades;
using AgendaSala.Domain.Interfaces;


namespace AgendaSala.Domain.Servicos
{
    public class ServicoValidarAgendamento : IServicoValidarAgendamento
    {

        public bool CompararAgendamentos(Agendamento agendamento, IList<Agendamento> listaAgendamento)
        {

            var _agendamentos = listaAgendamento
                .Where(a => 
                a.DataAgendamento.Date == agendamento.DataAgendamento.Date
                && agendamento.HoraInicial.TimeOfDay >=  a.HoraInicial.TimeOfDay
                && agendamento.HoraFinal.TimeOfDay <= a.HoraFinal.TimeOfDay

                || agendamento.HoraInicial.TimeOfDay < a.HoraInicial.TimeOfDay
                && agendamento.HoraFinal.TimeOfDay >  a.HoraInicial.TimeOfDay

                //|| agendamento.HoraFinal.TimeOfDay >= a.HoraFinal.TimeOfDay
                ).ToList();


            return _agendamentos.Count != 0 ? false : true ;
        }
    }
}
