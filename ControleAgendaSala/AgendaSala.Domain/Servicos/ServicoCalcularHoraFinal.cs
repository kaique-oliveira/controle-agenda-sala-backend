using AgendaSala.Domain.Entidades;
using AgendaSala.Domain.Interfaces;


namespace AgendaSala.Domain.Servicos
{
    public class ServicoCalcularHoraFinal : IServicoCalcularHoraFinal
    {
        public DateTime CalcularHora(DateTime horaInicial, DateTime duracao)
        {
            TimeSpan calculado = new TimeSpan(horaInicial.Ticks).Add(new TimeSpan(duracao.Ticks));

            return DateTime.Parse($"{calculado.Hours}:{calculado.Minutes}:{calculado.Seconds}");
            
        }
    }
}
