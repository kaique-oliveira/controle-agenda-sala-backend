using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entities;

namespace AgendaSala.Database.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
