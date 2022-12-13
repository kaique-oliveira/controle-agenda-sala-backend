
namespace AgendaSala.Domain.Interfaces
{
    public interface IServicoCalcularHoraFinal
    {
        DateTime CalcularHora(DateTime horaInicial, DateTime duracao);
    }
}
