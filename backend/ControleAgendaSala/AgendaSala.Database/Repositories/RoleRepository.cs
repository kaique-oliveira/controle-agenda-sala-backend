using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entities;

namespace AgendaSala.Database.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
