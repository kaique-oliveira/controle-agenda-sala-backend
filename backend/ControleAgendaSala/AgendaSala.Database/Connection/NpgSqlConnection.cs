using AgendaSala.Database.Interface;
using AgendaSala.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AgendaSala.Database.Connection
{
    public class NpgSqlConnection : INpgSqlConnection
    {
        private static ISessionFactory session;
        private static readonly string connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=DbAgendaSala";

        public ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }

            FluentConfiguration configuration = Fluently.Configure()
             .Database(PostgreSQLConfiguration.Standard.ConnectionString(connString))
             .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UserMapping>());
             //.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false, true, false));

            session = configuration.BuildSessionFactory();
            return session;

        }

        public ISession Open()
        {
            return CreateSession().OpenSession();
        }

    }
}
