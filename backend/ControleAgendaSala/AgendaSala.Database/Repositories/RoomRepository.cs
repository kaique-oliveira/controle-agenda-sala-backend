using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.Repositories
{
    public class RoomRepository : BaseRepository<Sala>, IRoomCrud
    {
        public RoomRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
