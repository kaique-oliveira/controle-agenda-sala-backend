using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgendaSala.Domain.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Tipo { get; set; }
        public virtual Setor Setor { get; set; }

    }
}

