using AgendaSala.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaSala.Domain.Mappings
{
    public class EventMapping : ClassMap<Event>
    {
        public EventMapping()
        {
            Table("tblEvent");

            Id(e => e.Id).GeneratedBy.Identity();

            Map(e => e.EventDate).Not.Nullable().CustomSqlType("date");
            Map(e => e.StartTime).Not.Nullable().CustomSqlType("time");
            Map(e => e.EndTime).Not.Nullable().CustomSqlType("time");
            Map(e => e.Duration).Not.Nullable().CustomSqlType("time");

            References(e => e.Room, "RoomId").Not.Nullable();
            References(e => e.User, "UserId").Not.Nullable();

        }
    }
}
