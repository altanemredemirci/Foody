using Foody.CORE.Entities;
using Foody.DAL.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Concrete.EfCore
{
    public class EfCoreGenericRepositoryDal<T, TContext> where T : class where TContext : DbContext
    {
        private readonly TContext _context;

        public EfCoreGenericRepositoryDal(TContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            //return filter == null
            //    ? context.Set<T>().ToList()
            //    : context.Set<T>().Where(filter).ToList();

            var entities = _context.Set<T>().AsQueryable();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }
            return entities.ToList();
        }

        public T GetOne(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update()
        {
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            return _context.SaveChanges();
        }
    }
}

