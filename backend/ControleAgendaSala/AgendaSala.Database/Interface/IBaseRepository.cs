namespace AgendaSala.Database.Interface
{
    public interface IBaseRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindId(int id);
        IList<T> FindAll();
    }
}
