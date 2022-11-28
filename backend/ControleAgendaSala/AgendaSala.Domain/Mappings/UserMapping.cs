using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;

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

            References(u => u.Role, "RoleId");

        }
    }
}
