using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AgendaSala.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Role Role { get; set; }

    }
}
