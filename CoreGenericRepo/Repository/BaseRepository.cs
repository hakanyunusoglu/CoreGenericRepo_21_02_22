using CoreGenericRepo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreGenericRepo.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class, new()
    {
        private DataContext db;
        public BaseRepository(DataContext _db)
        {
            db = _db;
        }
        public void Add(T entity)
        {
            Set().Add(entity);
        }

        public void Delete(T entity)
        {
            Set().Remove(entity);
        }

        public T Find(int id)
        {
           return Set().Find(id);
        }

        public T Find(string id)
        {
            return Set().Find(id);
        }

        public IQueryable<T> GeneralList()
        {
            return Set().AsQueryable();
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }

        public void Update(T entity)
        {
            Set().Update(entity);
        }
    }
}
