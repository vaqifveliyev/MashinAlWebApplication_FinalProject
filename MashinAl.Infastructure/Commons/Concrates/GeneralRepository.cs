using MashinAl.Infastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MashinAl.Infastructure.Commons.Concrates
{
    public abstract class GeneralRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly DbContext db;
        private readonly DbSet<T> table;


        public GeneralRepository(DbContext db)
        {
            this.db = db;
            this.table = db.Set<T>();
        }
        public T Add(T model)
        {
            table.Add(model);

            return model;
        }

        public T Edit(T model)
        {
            db.Entry(model).State = EntityState.Modified;
            return model;
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null)
                return table.FirstOrDefault();

            return table.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null)
                return table.AsQueryable();

            return table.Where(predicate).AsQueryable();
        }

        public void Remove(T model)
        {
            table.Remove(model);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
