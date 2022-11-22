using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_API.Entidades
{
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeOnly HourStart { get; set; }

        [Required]
        public TimeOnly HourEnd { get; set; }

        [Required]
        public int IdSetor { get; set; }
    }
}
