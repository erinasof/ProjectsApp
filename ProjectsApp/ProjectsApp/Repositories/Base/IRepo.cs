using ProjectsApp.Models;
using System.Collections.Generic;

namespace ProjectsApp.Repositories
{
    public interface IRepo<T, TKey> where T : PKEntity<TKey>
    {
        #region Methods
        T GetOne(TKey id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        #endregion
    }
}
