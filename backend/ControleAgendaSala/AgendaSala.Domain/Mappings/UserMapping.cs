using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Linq;

namespace AgendaSala.Domain.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("tblUser");

            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.UserName).Not.Nullable();
            Map(u => u.Email).Not.Nullable();
            Map(u => u.Password).Not.Nullable();

            References(u => u.Role)
            .Column("RoleId")
            .ForeignKey("fk_RoleUser")
            .Index("idx_fk_RoleUser")
            ;
        }
    }
}
