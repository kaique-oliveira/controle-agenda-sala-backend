using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entidades;

namespace AgendaSala.Database.Repositories
{
    public class RoleRepository : BaseRepository<Setor>, IRoleCrud
    {
        public RoleRepository(INpgSqlConnection connection) : base(connection)
        {
        }
    }
}
