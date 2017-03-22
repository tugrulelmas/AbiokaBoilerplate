using AbiokaBoilerplate.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AbiokaBoilerplate.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AbiokaDbContext context;

        public Repository(AbiokaDbContext context) {
            this.context = context;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(object id) {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() {
            var result = Query().ToList();
            return result;
        }

        public IQueryable<T> Query() => GetQuery<T>();

        protected IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class {
            var query = context.Set<TEntity>().AsQueryable();
            if (typeof(IDeletableEntity).IsAssignableFrom(typeof(TEntity))) {
                query = query.Where(e => !((IDeletableEntity)e).IsDeleted);
            }
            return query;
        }

        public IPage<T> GetPage(PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
