using NHibernate;

namespace AgendaSala.Database.Interface
{
    public interface INpgSqlConnection 
    {
        ISessionFactory CreateSession();

        ISession Open();
    }
}
