using AgendaSala.Database.Interfaces;
using NHibernate;
using NHibernate.Cfg;


namespace AgendaSala.Database.Conexao
{
    public class ConexaoDatabase : IConexao
    {
        private static ISessionFactory sessao;

        public ISessionFactory CriarSessao()
        {
            if (sessao != null)
            {
                return sessao;
            }

            Configuration cfg = new Configuration()
             .AddAssembly("AgendaSala.Domain");
            sessao = cfg.BuildSessionFactory();


            return sessao;

        }

        public ISession Abrir()
        {
            return CriarSessao().OpenSession();
        }

    }
}
