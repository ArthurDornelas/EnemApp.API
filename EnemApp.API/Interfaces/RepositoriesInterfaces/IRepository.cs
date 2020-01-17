using System.Collections.Generic;
using EnemApp.API.Models;

namespace EnemApp.API.Interfaces.RepositoriesInterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T obj);

        T Update(T obj);

        void Remove(int id);

        T GetById(int id);

        IList<T> SelectAll();
    }
}
