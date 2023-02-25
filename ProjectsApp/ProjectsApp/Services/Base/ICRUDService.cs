using ProjectsApp.Models;
using System.Collections.Generic;

namespace ProjectsApp.Services
{
    public interface ICRUDService<T, TKey> where T : PKEntity<TKey>
    {
        IEnumerable<T> GetItems();

        T GetItem(TKey id);

        void DeleteItem(T item);

        void SaveItem(T item);
    }
}
