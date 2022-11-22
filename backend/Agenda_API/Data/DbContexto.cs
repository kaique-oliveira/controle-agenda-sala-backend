using Agenda_API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Agenda_API.Data
{
    public class DbContexto : DbContext
    {

        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options) 
        {
        }
        

        public DbSet<Setor> Setor { get; set; } 
        public DbSet<Agendamento> Agendamento { get; set; }
    }
}
