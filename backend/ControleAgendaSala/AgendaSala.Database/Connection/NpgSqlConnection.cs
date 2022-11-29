using AgendaSala.Database.Interface;
using NHibernate;
using NHibernate.Cfg;


namespace AgendaSala.Database.Connection
{
    public class NpgSqlConnection : INpgSqlConnection
    {
        private static ISessionFactory session;

        public ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }

            Configuration cfg = new Configuration()
             .AddAssembly("AgendaSala.Domain");
            session = cfg.BuildSessionFactory();


            return session;

        }

        public ISession Open()
        {
            return CreateSession().OpenSession();
        }

    }
}
