using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaSala.Domain.Mappings
{
    public class RoomMapping : ClassMap<Room>
    {
        public RoomMapping()
        {
            Table("tblRoom");

            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.Name).Not.Nullable();
        }
    }
}
