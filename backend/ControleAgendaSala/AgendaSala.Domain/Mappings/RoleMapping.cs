using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Impl;

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

            //HasMany(r => r.Users).KeyColumn("Id");
            HasMany(r => r.Users)
                .Cascade.AllDeleteOrphan()
                .KeyColumn("Id");

            

        }

    }
}
