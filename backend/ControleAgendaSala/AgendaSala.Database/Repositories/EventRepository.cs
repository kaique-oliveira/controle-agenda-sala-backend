using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.Repositories
{
    public class EventRepository : BaseRepository<Agendamento>, IEventCrud
    {
        public EventRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
