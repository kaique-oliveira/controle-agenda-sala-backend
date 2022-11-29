using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entities;

namespace AgendaSala.Database.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
