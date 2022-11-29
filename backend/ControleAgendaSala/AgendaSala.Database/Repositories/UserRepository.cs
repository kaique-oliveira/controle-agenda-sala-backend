using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entities;

namespace AgendaSala.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
