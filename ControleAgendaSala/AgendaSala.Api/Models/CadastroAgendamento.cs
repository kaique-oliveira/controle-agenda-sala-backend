using AgendaSala.Domain.Entidades;

namespace AgendaSala.Api.Models
{
    public class CadastroAgendamento
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime Duracao { get; set; }
        public int IdSala { get; set; }
        public int IdUsuario { get; set; }

    }
}
