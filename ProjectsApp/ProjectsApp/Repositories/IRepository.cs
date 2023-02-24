using System.Collections.Generic;

namespace ProjectsApp.Repositories
{
    public interface IRepository<T>
    {
        #region Methods
        T GetOne(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        #endregion
    }
}
