using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreGenericRepo.Repository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        DbSet<T> Set();
        List<T> List();
        T Find(int id);
        T Find(string id);
        IQueryable<T> GeneralList();
        void Add(T entity);
        void Delete(T entity);
        void Save();
        void Update(T entity);
    }
}
