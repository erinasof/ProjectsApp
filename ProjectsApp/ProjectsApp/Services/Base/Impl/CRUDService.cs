using ProjectsApp.Models;
using ProjectsApp.Repositories;
using System.Collections.Generic;

namespace ProjectsApp.Services.Impl
{
    public abstract class CRUDService<T, TKey> : ICRUDService<T, TKey> where T : PKEntity<TKey>
    {

        private readonly IRepo<T, TKey> repository;

        public CRUDService(IRepo<T, TKey> repository)
        {
            this.repository = repository;
        }

        public void DeleteItem(T item)
        {
            repository.Delete(item);
        }

        public T GetItem(TKey id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<T> GetItems()
        {
            return repository.GetAll();
        }

        public void SaveItem(T item)
        {
            if (item.IsExist())
            {
                repository.Update(item);
            }
            else
            {
                repository.Add(item);
            }
        }
    }
}
