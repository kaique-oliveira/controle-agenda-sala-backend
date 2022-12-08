namespace AgendaSala.Database.Interfaces
{
    public interface ICrudBase<T>
    {
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);
        T BuscarPorId(int id);
        IList<T> BuscarTodos();
    }
}
