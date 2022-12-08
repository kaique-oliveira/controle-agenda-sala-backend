using AgendaSala.Database.Dal;
using AgendaSala.Database.Interface;
using NHibernate;

namespace AgendaSala.Repository.Repositories
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public void Delete(T entity)
        {
            //open session
            using (ISession _session = NhibernateConnection.Open())
            {
                //open transaction
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _session.Delete(entity);
                        //commit database
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception($"Erro ao deletar: {ex}");
                        }
                    }
                }

            }
        }

        public IList<T> FindAll()
        {
            //not use transaction
            //open session
            using (ISession _session = NhibernateConnection.Open())
            {
                return (from res in _session.Query<T>() select res).ToList();
            }
        }

        public T FindId(int id)
        {
            //not use transaction
            //open session
            using (ISession _session = NhibernateConnection.Open())
            {
                return _session.Get<T>(id);
            }
        }

        public void Insert(T entity)
        {
            //open session
            using (ISession _session = NhibernateConnection.Open())
            {
                //open transaction
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _session.Save(entity);
                        //commit database
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception($"Erro ao salvar: {ex}");
                        }
                    }
                }

            }
        }

        public void Update(T entity)
        {
            //open session
            using (ISession _session = NhibernateConnection.Open())
            {
                //open transaction
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _session.Update(entity);
                        //commit database
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception($"Erro ao atualizar: {ex}");
                        }
                    }
                }

            }
        }
    }
}
