using System.ComponentModel.DataAnnotations;

namespace AgendaSala.Domain.Entidades
{
    public class Sala
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }

    }
}
