using AgendaSala.Domain.Enum;
using System.ComponentModel.DataAnnotations;


namespace AgendaSala.Domain.Entities
{
    public class Role
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual AcessType AcessType { get; set; }
        public virtual IList<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}
