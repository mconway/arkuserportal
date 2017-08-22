using System.Collections.Generic;
using System.Linq;

namespace ArkPortalWebApi.Models
{
    public interface IRepositoryBase<T>
    {
        void Add(T item);
        IQueryable<T> GetAll();
        T Find(int key);
        T Remove(int key);
        void Update(T item);
    }
}