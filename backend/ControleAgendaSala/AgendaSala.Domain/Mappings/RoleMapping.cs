using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaSala.Domain.Mappings
{
    public class RoleMapping : ClassMap<Role>
    {
        public RoleMapping()
        {
            Table("tblRole");

            Id(r => r.Id).GeneratedBy.Identity();

            Map(r => r.Name).Not.Nullable();
            Map(r => r.AcessType).Not.Nullable();
        }

    }
}
