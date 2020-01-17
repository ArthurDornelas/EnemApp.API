using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Interfaces.RepositoriesInterfaces;
using EnemApp.API.Models;
using EnemApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EnemApp.API.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _dbContext;

        public BaseRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T objeto)
        {
            _dbContext.Set<T>().Add(objeto);
            _dbContext.SaveChanges();
            return objeto;
        }

        public T Update(T objeto)
        {
            _dbContext.Entry(objeto).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return objeto;
        }

        public void Remove(int id)
        {
            _dbContext.Set<T>().Remove(this.GetById(id));
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}
