using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSala.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindId(int id);
        IList<T> FindAll();
    }
}