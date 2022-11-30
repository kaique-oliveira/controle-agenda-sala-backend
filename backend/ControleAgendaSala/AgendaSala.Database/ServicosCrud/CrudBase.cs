using AgendaSala.Database.Interfaces;
using NHibernate;

namespace AgendaSala.Database.ServicosCrud
{
    public class CrudBase<T> : ICrudBase<T> where T : class
    {
        private readonly IConexao _conexao;

        public CrudBase(IConexao conexao)
        {
            _conexao = conexao;
        }

        public void Deletar(T entity)
        {
            //open session
            using (ISession _sessao = _conexao.Abrir())
            {
                //open transaction
                using (ITransaction _transacao = _sessao.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _sessao.Delete(entity);
                        //commit database
                        _transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transacao.WasCommitted)
                        {
                            _transacao.Rollback();
                            throw new Exception($"Erro ao deletar: {ex}");
                        }
                    }
                }

            }
        }

        public IList<T> BuscarTodos()
        {
            //not use transaction
            //open session
            using (ISession _sessao = _conexao.Abrir())
            {
                return (from res in _sessao.Query<T>() select res).ToList();
            }
        }

        public T BuscarPorId(int id)
        {
            //not use transaction
            //open session
            using (ISession _sessao = _conexao.Abrir())
            {
                return _sessao.Get<T>(id);
            }
        }

        public void Inserir(T entity)
        {
            //open session
            using (ISession _sessao = _conexao.Abrir())
            {
                //open transaction
                using (ITransaction _transacao = _sessao.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _sessao.Save(entity);
                        //commit database
                        _transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transacao.WasCommitted)
                        {
                            _transacao.Rollback();
                            throw new Exception($"Erro ao salvar: {ex}");
                        }
                    }
                }

            }
        }

        public void Atualizar(T entity)
        {
            //open session
            using (ISession _sessao = _conexao.Abrir())
            {
                //open transaction
                using (ITransaction _transacao = _sessao.BeginTransaction())
                {
                    try
                    {
                        //save session
                        _sessao.Update(entity);
                        //commit database
                        _transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transacao.WasCommitted)
                        {
                            _transacao.Rollback();
                            throw new Exception($"Erro ao atualizar: {ex}");
                        }
                    }
                }

            }
        }
    }
}
