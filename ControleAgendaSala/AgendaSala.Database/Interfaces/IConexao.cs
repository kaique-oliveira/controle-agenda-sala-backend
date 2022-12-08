using NHibernate;

namespace AgendaSala.Database.Interfaces
{
    public interface IConexao 
    {
        ISessionFactory CriarSessao();

        ISession Abrir();
    }
}
