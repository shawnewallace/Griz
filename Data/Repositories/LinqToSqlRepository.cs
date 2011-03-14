using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Griz.Data.Interfaces;

namespace Griz.Data.Repositories
{
    public class LinqToSqlRepository<T, TKey> : IRepository<T, TKey>
    where T : class, IEntity<TKey>
    {
        public IUnitOfWork UnitOfWork
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Func<T, bool> expression)
        {
            throw new NotImplementedException();
        }

        public T GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public TKey Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T DeleteById(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
