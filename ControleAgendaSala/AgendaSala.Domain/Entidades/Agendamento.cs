
namespace AgendaSala.Domain.Entidades
{
    public class Agendamento
    {
        public virtual int Id { get; set; }
        public string Titulo { get; set; }
        public virtual DateTime DataAgendamento { get; set; }
        public virtual DateTime HoraInicial { get; set; }
        public virtual DateTime HoraFinal { get; set; }
        public virtual DateTime Duracao { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
