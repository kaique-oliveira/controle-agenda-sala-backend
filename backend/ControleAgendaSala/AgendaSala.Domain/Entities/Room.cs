using System.ComponentModel.DataAnnotations;

namespace AgendaSala.Domain.Entities
{
    public class Room
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }
}
