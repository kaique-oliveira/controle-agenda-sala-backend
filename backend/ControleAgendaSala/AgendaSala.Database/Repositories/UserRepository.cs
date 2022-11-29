using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.Repositories
{
    public class UserRepository : BaseRepository<Usuario>, IUserCrud
    {
        public UserRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
